using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    private float moveDistance = 0.05f;

    public float random;

    //public SpriteRenderer MovingSpeedUpImage;
    //public SpriteRenderer ShootingSpeedUpImage;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("MovePowerUp", Time.deltaTime, Time.deltaTime);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePowerUp();
        transform.Rotate(Vector3.back * 50 * Time.deltaTime, Space.World);
    }

    void MovePowerUp()
    {
        // Get the current position of the game object on the horizontal X-axis
        float currentPositionX = gameObject.transform.position.x;

        // Calculate the new position the game object is expected to move to
        float newPositionX = currentPositionX + moveDistance;

        // The current position of the game object along the vertical Y-axis. We don't want to move the object vertically,
        // so we keep the value as is
        float currentPositionY = gameObject.transform.position.y;

        // Combine the X and Y values of the new position together in a new Vector2 variable
        Vector2 newPosition = new Vector2(newPositionX, currentPositionY);

        /*  Apply the new calculated position to the object's transform to actually make it move on screen
            *  The "position" property in transform is either a Vector2 (2d) or Vector3 (3d) data type, so we need to assign the values
            *  as one of those data types. Hence why newPosition is Vector2 data type
            */
        gameObject.transform.position = newPosition;

        if (currentPositionX >= 14)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check the tag on the other game object. If it's the projectile's tag,
        //  destroy both this game object and the projectile
        if (otherCollider.tag == "Projectile")
        {
            random = Random.Range(0f, 1f);
          
            if (random < 0.5f)
            {
                gm.ShootingSpeedUpgrade();
            }
            else
            {
                gm.MovingSpeedUpgrade();
            }

            Destroy(gameObject);  
        }
    }
}

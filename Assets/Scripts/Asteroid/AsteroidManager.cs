using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    // Start is called before the first frame update

    // The min and max limits on the horizontal X-axis where this game object can move within
    public float minPosX;
    private float maxPosX = 14;

    // How far to move per one step
    private float moveDistance = 0.01f;
    
    // A boolean to check which direction the game object is currently moving
    void Start()
    {
        InvokeRepeating("MoveAsteroid", Time.deltaTime, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the asteroid around its z-axis.
        transform.Rotate(Vector3.forward * 25 * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check the tag on the other game object. If it's the projectile's tag,
        //  destroy both this game object and the projectile
        if (otherCollider.tag == "Projectile")
        {
            // Get the game object, as a whole, that's attached to the Collider2D component
            Destroy(otherCollider.gameObject);
        }
    }
    void MoveAsteroid()
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

        if(currentPositionX >= 14)
        {  
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    // Start is called before the first frame update

    // The min and max limits on the horizontal X-axis where this game object can move within
    public float minPosX;
    private float maxPosX = 14;

    // How far to move per one step
    private float moveDistance = 0.05f;
    
    void Start()
    {
        //InvokeRepeating("MoveAsteroid", Time.deltaTime, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveAsteroid();
        //Rotate the asteroid around its z-axis.
        transform.Rotate(Vector3.forward * 25 * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check the tag on the other game object. If it's a projectile's tag, destroys the projectile.
        if (otherCollider.tag == "Projectile" || otherCollider.tag == "AlienProjectile")
        {
        
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

        //Destroy the object after moving out of screen.
        if(currentPositionX >= maxPosX)
        {  
            Destroy(gameObject);
        }
    }
}

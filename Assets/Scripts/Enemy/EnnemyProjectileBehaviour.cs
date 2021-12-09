using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the behaviour of the projectile game object
public class EnnemyProjectileBehaviour : MonoBehaviour
{
    // How fast will the project travel
    public float speed;

    // How much time, in seconds, before the projectile destroys itself (if it hits nothing and escapes the play area)
    public float destroyAfter = 4f;

    // Start is called before the first frame update
    void Start()
    {
        // Call the DestroyProjectile function (note its written as string, this is how Invoke takes its parameter)
        // after a specific amount of time (seconds) set by the destroyAfter variable
        //Invoke("DestroyProjectile", destroyAfter);
        Destroy(gameObject, destroyAfter);
    }

    // Update is called once per frame
    void Update()
    {
        // As soon as the projectile is instantiated in the game scene, transform.Translate will start
        // moving it up one unit, multiplied by the speed and Time.deltaTime for cpu optimisation
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    /*
    void DestroyProjectile()
    {
		// Destroy the game object this script is on (the projectile game object)
        
    }
    */
}

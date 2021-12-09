using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the player to shoot projectiles by instantiating them during run-time/gameplay
public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;

    public AudioSource audioSource;
    public AudioClip playerLaserShotSFX;

    public float laserCooldDown = 1;
    private float timer = 0;
   
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
		// Check if the player pressed the spacebar, mapped to the Jump input in project settings,
        // to make them shoot accorind to the cooldown.
        if (Input.GetButtonDown("Jump") && timer >= laserCooldDown)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
 
        //Play the laser shot sound
        audioSource.PlayOneShot(playerLaserShotSFX);
    }
}

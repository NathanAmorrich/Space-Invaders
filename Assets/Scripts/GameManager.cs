using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject powerUP;
    public Text powerUpInfo;

    public bool isShootingSpeedIncreased = false;
    public bool isMoveSpeedIncreased = false;

    private PlayerController playerParameters;
    private Shooter shootParameters;

    private float timerAsteroid, timerPowerUp, timerRemoveUpgrade = 0;

    void Start()
    {
        playerParameters = GameObject.Find("Player").GetComponent<PlayerController>();
        shootParameters = GameObject.Find("Player").GetComponent<Shooter>();
        powerUpInfo = GameObject.Find("Player/Canvas_powerUp/PowerUpInfo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timerAsteroid += Time.deltaTime;
        timerPowerUp += Time.deltaTime;


        //Spawn an asteroid every 5s with a random y position.
        if (timerAsteroid >= 5)
        { 
            Instantiate(asteroid, new Vector3(-14, Random.Range(-2.15f, 0.25f), 0), Quaternion.identity);
            timerAsteroid = 0;   
        }

        //Spawn an upgrade every 10s with a random y position.
        if (timerPowerUp >= 10)
        {
            Instantiate(powerUP, new Vector3(-14, Random.Range(-2.15f, 0.25f), 0), Quaternion.identity);
            timerPowerUp = 0;
        }

        //If the player got an upgrade
        if (isMoveSpeedIncreased == true || isShootingSpeedIncreased == true)
        {
            
            timerRemoveUpgrade += Time.deltaTime;

            //Remove the upgrade and the info text after 5s
            if (timerRemoveUpgrade >= 5)
            {
                if (isMoveSpeedIncreased == true)
                {
                    RemoveMovingSpeedUpgrade();
                }
                else
                {
                    RemoveShootingSpeedUpgrade();
                }
                timerRemoveUpgrade = 0;
            }
        }
    }

    public void ShootingSpeedUpgrade()
    {
        isShootingSpeedIncreased = true;
        shootParameters.laserCooldDown = 0.1f;
        powerUpInfo.gameObject.SetActive(true);
        powerUpInfo.text = "SHOOTING SPEED UP !";
    }

    void RemoveShootingSpeedUpgrade()
    {
        isShootingSpeedIncreased = false;
        shootParameters.laserCooldDown = 1f;
        powerUpInfo.gameObject.SetActive(false);
    }

    public void MovingSpeedUpgrade()
    {
        isMoveSpeedIncreased = true;
        playerParameters.moveSpeed = 10;
        powerUpInfo.gameObject.SetActive(true);
        powerUpInfo.text = "MOVE SPEED UP !";
    }

    void RemoveMovingSpeedUpgrade()
    {
        isMoveSpeedIncreased = false;
        playerParameters.moveSpeed = 5;
        powerUpInfo.gameObject.SetActive(false);
    }



}

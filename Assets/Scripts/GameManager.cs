using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject powerUP;
    public Text powerUpInfo, gameEndingTXT, scoreTXT;

    public bool isShootingSpeedIncreased = false;
    public bool isMoveSpeedIncreased = false;

    public int maxScore = 1350;

    private PlayerController playerParameters;
    private Shooter shootParameters;

    private int score = 0;
    private float timerAsteroid, timerPowerUp, timerRemoveUpgrade = 0;
    

    void Start()
    {
        playerParameters = GameObject.Find("Player").GetComponent<PlayerController>();
        shootParameters = GameObject.Find("Player").GetComponent<Shooter>();
        powerUpInfo = GameObject.Find("Player/Canvas_powerUp/PowerUpInfo").GetComponent<Text>();
        scoreTXT = GameObject.Find("Canvas/ScoreTXT").GetComponent<Text>();

        gameEndingTXT = GameObject.Find("Canvas/GameEndingTXT").GetComponent<Text>();
        gameEndingTXT.enabled = false;
    }

    // Update is called once per frame.
    void Update()
    {
        timerAsteroid += Time.deltaTime;
        timerPowerUp += Time.deltaTime;

        //Spawn an asteroid every 8s with a random y position.
        if (timerAsteroid >= 8)
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

        //If the player got an upgrade.
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

        //If the player lost, pause the game.
        if (GameObject.Find("Player") == null)
        {
            Time.timeScale = 0;
        }

        //If the player reach the max score.
        if (scoreTXT.text == "Score: "+ maxScore.ToString())
        {
            gameEndingTXT.enabled = true;
            gameEndingTXT.text = "Win";
            Time.timeScale = 0;
        }
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreTXT.text = "Score: " + score.ToString();
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

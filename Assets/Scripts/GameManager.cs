using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject asteroid, powerUP, enemiesGroupTop;
    
    public Text powerUpInfo, gameEndingTXT, scoreTXT;
    public Button restartButton;

    public bool isShootingSpeedIncreased = false;
    public bool isMoveSpeedIncreased = false;
    public bool isTimePaused = false;

    public int maxScore = 1350;

    private PlayerController playerParameters;
    private Shooter shootParameters;

    private int score = 0;
    public float timerAsteroid, timerPowerUp, timerRemoveUpgrade = 0;
    

    void Start()
    {
        isTimePaused = false;

        playerParameters = GameObject.Find("Player").GetComponent<PlayerController>();
        shootParameters = GameObject.Find("Player").GetComponent<Shooter>();
        powerUpInfo = GameObject.Find("Player/Canvas_powerUp/PowerUpInfo").GetComponent<Text>();
        scoreTXT = GameObject.Find("Canvas/ScoreTXT").GetComponent<Text>();

        //Hiding ending text and restart button at the beginning of the game.
        gameEndingTXT = GameObject.Find("Canvas/GameEndingTXT").GetComponent<Text>();
        gameEndingTXT.enabled = false;

        gameEndingTXT = GameObject.Find("Canvas/GameEndingTXT").GetComponent<Text>();
        gameEndingTXT.enabled = false;

        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false);
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
            powerUpInfo.text = "UPGRADE TIME: "+ (5-Mathf.FloorToInt(timerRemoveUpgrade))+"s";
           
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
        if (GameObject.Find("Player") == null && isTimePaused == false)
        {
            Time.timeScale = 0;
            isTimePaused = true;

            gameEndingTXT.enabled = true;
            gameEndingTXT.text = "Game Over";
            restartButton.gameObject.SetActive(true);
        }

        //If the player reach the max score.
        if (GameObject.Find("Enemies").transform.childCount == 0 && isTimePaused == false)
        {
            Time.timeScale = 0;
            isTimePaused = true;

            gameEndingTXT.enabled = true;
            restartButton.gameObject.SetActive(true);
            gameEndingTXT.text = "Win";
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
    }

    void RemoveMovingSpeedUpgrade()
    {
        isMoveSpeedIncreased = false;
        playerParameters.moveSpeed = 5;
        powerUpInfo.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        //Reset the game
        SceneManager.LoadScene("SpaceInvaders");
        //Resume the game
        Time.timeScale = 1; 
    }



}

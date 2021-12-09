using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTXT;
    public int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        print("Score = " + score);
        scoreTXT.text = "Score: " + score.ToString();
    }
}

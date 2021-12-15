using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{ 
    public void RestartGame()
    {
        
        SceneManager.LoadScene("SpaceInvaders");
        Time.timeScale = 1;
        
    }
}

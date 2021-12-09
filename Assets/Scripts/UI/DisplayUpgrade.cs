using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    //private Text text;
    private GameObject player, shootingSpeedUI;
 
    void Start()
    {
        player = GameObject.Find("Player");
        shootingSpeedUI = GameObject.Find("Canvas/ShootingSpeedUI");
    }

    // Update is called once per frame
    void Update()
    {
        shootingSpeedUI.transform.position = player.transform.position;
        print(shootingSpeedUI.transform.position.x);
    }
}

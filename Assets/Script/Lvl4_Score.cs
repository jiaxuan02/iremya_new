using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lvl4_Score : MonoBehaviour
{
    public GameObject floor3;
    public GameObject floor2;
    public TextMeshProUGUI myscore;
    public TextMeshProUGUI mylives;
    public static int scores;
    public static int lives = 2;


    // Start is called before the first frame update
    void Start()
    {
        floor3.SetActive(false);
        floor2.SetActive(false);
        scores = 0;
        myscore.text = "Scores: " + scores;
        mylives.text = "Lives: " + lives;
    }

    private void Update() {
        unlockDoors();
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.CompareTag("Collection"))
        {
            scores++;
            Destroy(Coin.gameObject);//destroy when the player touches the coin
            myscore.text = "Scores: " + scores;
        }
    }

    public void unlockDoors(){
        if(scores == 3)
        {
            floor3.SetActive(true);
        }
        
        if(scores == 6){
            floor2.SetActive(true);
        }
    }


}
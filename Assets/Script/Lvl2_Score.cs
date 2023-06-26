using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lvl2_Score : MonoBehaviour
{
    [SerializeField] private GameObject doors;
    [SerializeField] private GameObject doors2;
    [SerializeField] private GameObject doors3;
    [SerializeField] private GameObject panels;
    public TextMeshProUGUI myscore;
    public TextMeshProUGUI mylives;
    public static int scores;
    public static int lives;


    // Start is called before the first frame update
    void Start()
    {
        panels.SetActive(false);
        doors.SetActive(true);
        doors2.SetActive(true);
        doors3.SetActive(true);
        scores = 0;
        myscore.text = "Books: " + scores;
        lives = 2;
        mylives.text = "Lives: " + lives;
    }

    private void Update() {
        if(scores == 3){
            doors.SetActive(false);
        }else if(scores == 6){
            doors2.SetActive(false);
        }else if(scores == 9){
            doors3.SetActive(false);
        }

        mylives.text = "Lives: " + lives;
        if(lives == 0){
            panels.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.CompareTag("Collection"))
        {
            scores++;
            Destroy(Coin.gameObject);//destroy when the player touches the coin
            myscore.text = "Books: " + scores;
        }
    }


}

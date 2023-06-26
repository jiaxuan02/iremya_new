using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lvl2_Score : MonoBehaviour
{
    [SerializeField] private GameObject doors;
    public TextMeshProUGUI myscore;
    public static int scores;


    // Start is called before the first frame update
    void Start()
    {
        scores = 0;
        myscore.text = "Books: " + scores;
    }

    private void Update() {
        if(scores == 3){
            doors.SetActive(true);
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

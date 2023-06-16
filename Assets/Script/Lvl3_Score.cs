using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lvl3_Score : MonoBehaviour
{
    public TextMeshProUGUI myscore;
    public static int scores;


    // Start is called before the first frame update
    void Start()
    {
        scores = 0;
        myscore.text = "Book not found";
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.CompareTag("Collection"))
        {
            scores++;
            Destroy(Coin.gameObject);//destroy when the player touches the coin
            myscore.text = "Book Found!!";
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lvl1_Score : MonoBehaviour
{
    public TextMeshProUGUI myscore;
    public GameObject imgs;
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
            imgs.SetActive(false);
            Destroy(Coin.gameObject);//destroy when the player touches the coin
            myscore.text = "Book Found!!";
        }
    }


}

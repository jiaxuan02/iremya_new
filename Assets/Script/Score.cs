using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text myscore;
    private int scores;

    // Start is called before the first frame update
    void Start()
    {
        scores = 0;
        myscore.text = "Score : " + scores;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "Collection")
        {
            scores++;
            Destroy(Coin.gameObject);//destroy when the player touches the coin
            myscore.text = "Score: " + scores;
        }
    }


}

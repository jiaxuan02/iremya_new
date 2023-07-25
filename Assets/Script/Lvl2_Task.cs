using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2_Task : MonoBehaviour
{
    [SerializeField] private GameObject img1;
    [SerializeField] private GameObject img2;
    [SerializeField] private GameObject img3;
    [SerializeField] private GameObject txt1;
    [SerializeField] private GameObject txt2;
    [SerializeField] private GameObject txt3;

    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        img1.SetActive(true);
        img2.SetActive(false);
        img3.SetActive(false);
        txt1.SetActive(true);
        txt2.SetActive(false);
        txt3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Lvl2_Score.scores == 9)
        {
            img1.SetActive(false);
            img2.SetActive(true);
            img3.SetActive(false);
            txt1.SetActive(false);
            txt2.SetActive(true);
            txt3.SetActive(false);
        }

        if (Lvl2_Friend_Trigger.talked == true)
        {
            img1.SetActive(false);
            img2.SetActive(false);
            img3.SetActive(true);
            txt1.SetActive(false);
            txt2.SetActive(false);
            txt3.SetActive(true);
        }
    }

}

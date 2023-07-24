using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVl2_Door_WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cue;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject stars1;
    [SerializeField] private GameObject stars2;
    [SerializeField] private GameObject stars3;

    private bool inRange;

    private void Start()
    {
        // Initialize objects as needed in the Inspector
        cue.SetActive(false);
        panel.SetActive(false);
        stars1.SetActive(false);
        stars2.SetActive(false);
        stars3.SetActive(false);
    }

    public static bool win = false;
    private void Update()
    {
        if (inRange)
        {
            cue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Time.timeScale = 1f; // Set back to 1 to resume normal time flow
                cue.SetActive(true);

                if (Lvl2_Score.lives == 2)
                {
                    stars1.SetActive(true);
                }
                if (Lvl2_Score.scores == 9)
                {
                    stars2.SetActive(true);
                }
                if (Lvl2_Friend_Trigger.talked == true)
                {
                    stars3.SetActive(true);
                }

                win = true;
            }
        }
        else
        {
            cue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Lvl4_WinTrigger1 : MonoBehaviour
{

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualcue;
    [SerializeField] private GameObject winpanel;
    [SerializeField] private GameObject stars1;
    [SerializeField] private GameObject stars2;
    [SerializeField] private GameObject stars3;

    private bool playerInRange;

    private void Start()
    {
        // Initialize objects as needed in the Inspector
        visualcue.SetActive(false);
        winpanel.SetActive(false);
        stars1.SetActive(false);
        stars2.SetActive(false);
        stars3.SetActive(false);
    }

    private void Update() {

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            visualcue.SetActive(true);

            if (Lvl4_Score.scores == 3)
            {
                stars1.SetActive(true);
            }
            if (Lvl4_Score.scores == 6)
            {
                stars2.SetActive(true);
            }
            if (Lvl4_Score.lives == 2)
            {
                stars3.SetActive(true);
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                winpanel.SetActive(true);
            }
            
        }
        else{
            visualcue.SetActive(false);
        }
    }

    private void Awake() {
        
        playerInRange = false;
        visualcue.SetActive(false);        
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.tag == "Player"){
            playerInRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collider) {
        
        if(collider.gameObject.tag == "Player"){
            playerInRange = false;
        }
    }
}

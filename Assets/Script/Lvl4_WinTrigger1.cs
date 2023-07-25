using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Lvl4_WinTrigger1 : MonoBehaviour
{

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualcue;
    [SerializeField] private GameObject winpanel;
    [SerializeField] private GameObject scores;
    [SerializeField] private GameObject scores2;
    [SerializeField] private GameObject scores3;
    private bool playerInRange;

    private void Update() {

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            visualcue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                Time.timeScale = 0;
                winpanel.SetActive(true);
                scores.SetActive(true);
                if(Lvl4_Score.scores == 6){
                    scores2.SetActive(true);
                }
                if(Lvl4_Score.lives == 2){
                    scores3.SetActive(true);
                }
       
            }
            
        }
        else{
            visualcue.SetActive(false);
        }
    }

    private void Awake() {
        

        playerInRange = false;
        visualcue.SetActive(false);
        scores.SetActive(false);   
        scores2.SetActive(false);
        scores3.SetActive(false);
        winpanel.SetActive(false);           
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

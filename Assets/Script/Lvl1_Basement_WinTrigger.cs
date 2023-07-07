using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_Basement_WinTrigger : MonoBehaviour
{
    //[SerializeField] Score sc;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualcue;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject stars1;
    [SerializeField] private GameObject stars2;
    [SerializeField] private GameObject stars3;

    [Header("JSON file")]
    [SerializeField] private TextAsset inkJSON;

    public static bool policeCalled = false;
    private bool playerInRange;

    private void Update() {

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            visualcue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                if(Lvl1_PhoneTrigger.policeCalled == false){
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);

                }
                else{
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    if(Lvl1_Score.scores == 1){
                        stars1.SetActive(true);
                    }
                    if(Lvl1_Keys.sc == 3){
                        stars2.SetActive(true);
                    }
                    if(Lvl1_PhoneTrigger.policeCalled == true){
                        stars3.SetActive(true);
                    }
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
        panel.SetActive(false);        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Lvl4_NPCBAD : MonoBehaviour
{

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualcue;

    [Header("JSON file")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset inkJSON2;

    public static bool policeCalled = false;
    private bool playerInRange;

    private Story story;

    private void Update() {

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            visualcue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(Lvl1_Score.scores == 1)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                    policeCalled = true;

                    story.BindExternalFunction("startQuest", (string questId) => {
                        Debug.Log(questId);
                    });

                }
                else{
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON2) ;
                    policeCalled = false;
                
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

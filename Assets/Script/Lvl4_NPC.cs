using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Lvl4_NPC : MonoBehaviour
{

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualcue;
    [SerializeField] private GameObject signs;
    [SerializeField] public GameObject obj;
    

    [Header("JSON file")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

 

    private void Update() {

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            visualcue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                    signs.SetActive(true);
                    obj.SetActive(true);
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

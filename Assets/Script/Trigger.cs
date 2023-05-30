using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject door;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualcue;

    [Header("JSON file")]
    [SerializeField] private TextAsset inkJSON;

    public static bool policeCalled = false;
    private bool playerInRange;

    private void Update() {

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            visualcue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                if(Key.lockd == true){
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);

                }
                else
                {
                    Destroy(door);
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

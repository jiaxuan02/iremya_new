using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject cue;

    [Header("JSON file")]
    [SerializeField] private TextAsset inkJSON;

    public static bool policeCalled = false;
    private bool InRange;

    private void Update() {

        if (InRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            cue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                if(Key.lockd == true){
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);

                }
            }
        }
        else{
            cue.SetActive(false);
        }
    }

    private void Awake() {
        
        InRange = false;
        cue.SetActive(false);     
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.tag == "Player"){
            InRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collider) {
        
        if(collider.gameObject.tag == "Player"){
            InRange = false;
        }
    }
}

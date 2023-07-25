using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2_Friend_Trigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject cue;

    [SerializeField] private GameObject door;

    [Header("JSON file")]
    [SerializeField] private TextAsset inkJSON;

    public static bool talked = false;

    public static bool policeCalled = false;
    private bool InRange;

    private void Update() {

        if (InRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            cue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                    door.SetActive(true);
                    talked = true;
            }
        }
        else{
            cue.SetActive(false);
        }
    }

    private void Awake() {
        door.SetActive(false);
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

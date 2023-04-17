using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualcue;

    [Header("JSON file")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;

    private void Update() {
        if (playerInRange){
            visualcue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                Debug.Log(inkJSON.text);
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

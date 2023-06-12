using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destinate : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject cue;

    [SerializeField] private Transform destination;
     private bool InRange;
 
    // Update is called once per frame
    public Transform GetDestination(){
        return destination;
    }

     private void Awake() {
        InRange = false;
        cue.SetActive(false);     
    }

    private void Update() {
        if (InRange){
            cue.SetActive(true);
        }
        else{
            cue.SetActive(false);
        }
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

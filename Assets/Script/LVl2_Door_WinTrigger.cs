using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVl2_Door_WinTrigger : MonoBehaviour
{
    [SerializeField] public GameObject cue;
    [SerializeField] private GameObject panel;

    private bool InRange;
    public static bool win = false;

    private void Awake() {
        cue.SetActive(false);
    }
    private void Update() {
        if (InRange){
            cue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    win = true;
            }
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

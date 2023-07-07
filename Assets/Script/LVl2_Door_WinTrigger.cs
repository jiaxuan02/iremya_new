using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVl2_Door_WinTrigger : MonoBehaviour
{
    [SerializeField] public GameObject cue;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject stars1;
    [SerializeField] private GameObject stars2;
    [SerializeField] private GameObject stars3;

    private bool InRange;
    public static bool win = false;

    private void Awake() {
        cue.SetActive(false);
        stars1.SetActive(false);
        stars2.SetActive(false);
        stars3.SetActive(false);
    }
    private void Update() {
        if (InRange){
            cue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F)){
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    if(Lvl2_Score.lives == 2)
                    {
                        stars1.SetActive(true);
                    }
                    if(Lvl2_Score.scores == 9)
                    {
                        stars2.SetActive(true);
                    }
                    if(Lvl2_Friend_Trigger.talked == true)
                    {
                        stars3.SetActive(true);
                    }
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

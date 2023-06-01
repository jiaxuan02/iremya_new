using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winDOor : MonoBehaviour
{
    [SerializeField] public GameObject door;
    [SerializeField] public GameObject panel;

    private void Awake() {
        panel.SetActive(false);
    }
    void Update() {
        if(Lvl2Trigger.win == true)
        door.SetActive(true);

        if(Input.GetKeyDown(KeyCode.F)){
            panel.SetActive(true);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2_Teleport : MonoBehaviour
{
    private GameObject curTel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(curTel != null)
            {
                transform.position = curTel.GetComponent<Lvl2_Destination>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Teleporter"))
        {
            curTel = other.gameObject;              

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Teleporter")){
            if(other.gameObject == curTel){
                curTel = null;
            }
        }
    }
}

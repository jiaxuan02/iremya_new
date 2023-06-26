using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_Keys : MonoBehaviour
{
    public GameObject img;
    public GameObject door;
    public static bool lockd = true;
   private void OnTriggerEnter2D(Collider2D other) {
    
    if(other.CompareTag("Player")){
        door.GetComponent<BoxCollider2D>().enabled = false;
        img.SetActive(false);
        lockd = false;
        Destroy(gameObject);
        Destroy(door);
    }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
   private void OnTriggerEnter2D(Collider2D other) {
    
    if(other.CompareTag("Player")){
        door.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }
   }
}

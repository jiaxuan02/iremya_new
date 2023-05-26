using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreThings : MonoBehaviour
{   
    [SerializeField] private Collider2D m_CrouchDisableCollider;
    
    void Start() {
        m_CrouchDisableCollider = this.GetComponent<Collider2D> ();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Furniture")){
			m_CrouchDisableCollider.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
         if(other.CompareTag("Furniture")){
			m_CrouchDisableCollider.enabled = false;
        }
    }
}

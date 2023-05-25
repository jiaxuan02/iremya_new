using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rB;

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0f){
            isClimbing = true;
        } 
    }

    private void FixedUpdate() {
        if(isClimbing){
            rB.gravityScale = 0f;
            rB.velocity = new Vector2(rB.velocity.x, vertical * speed);

        }
        else{
            rB.gravityScale =  4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ladder")){
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Ladder")){
            isLadder = false;
            isClimbing = false;
        }
    }
}

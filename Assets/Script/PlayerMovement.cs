using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator; //animation run

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    private Lvl1_Ladders ladderController; // Reference to Lvl1_Ladders script //new

    private void Start()
    {
        ladderController = GetComponent<Lvl1_Ladders>(); // Get the Lvl1_Ladders script from the same GameObject //new
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); //animation run

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true); //animation jump
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (ladderController != null && ladderController.isClimbing) // Check if ladderController is not null before accessing its members //new
        {
            // Check if the player is pressing "W" (up) or "S" (down) to play the climbing animation
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                animator.SetBool("IsClimbing", true);
            }
            else
            {
                animator.SetBool("IsClimbing", false);
            }
        }
        else
        {
            animator.SetBool("IsClimbing", false);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false); //animation jump
    }

    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

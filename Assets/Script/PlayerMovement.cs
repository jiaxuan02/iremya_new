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
    private bool inDialogue = false; // Flag to track if the player is in dialogue

    private DialogueSystem dialogueSystem; // Reference to the DialogueSystem script
    private Lvl1_Ladders ladderController; // Reference to the Lvl1_Ladders script

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>(); // Find the DialogueSystem in the scene
        ladderController = GetComponent<Lvl1_Ladders>(); // Get the Lvl1_Ladders script from the same GameObject
    }

    void Update()
    {
        // Check if the dialogue panel is active, if yes, disable movement controls
        if (inDialogue || (dialogueSystem != null && dialogueSystem.dialoguePanel.activeSelf))
        {
            horizontalMove = 0f;
            jump = false;
            crouch = false;
            animator.SetFloat("Speed", 0f); // Stop the run animation
        }
        else // Enable movement controls when not in dialogue
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

            // Check if ladderController is not null before accessing its members
            if (ladderController != null && ladderController.isClimbing)
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
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false); //animation jump
    }

    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying || inDialogue)
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

    // Method to set the inDialogue flag
    public void SetInDialogue(bool value)
    {
        inDialogue = value;
    }
}

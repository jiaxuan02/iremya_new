using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public GameObject dialoguePanel;
    public GameObject interactionPrompt;

    private bool playerInRange = false;
    private bool dialogueTriggered = false;
    private bool dialogueEnded = false; // New variable to track if dialogue has ended

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactionPrompt.SetActive(true);

            // Reset the dialogueEnded flag when the player re-enters the NPC's hitbox
            dialogueEnded = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionPrompt.SetActive(false);

            // Reset the dialogueTriggered flag when the player moves away from the NPC
            dialogueTriggered = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !dialogueTriggered)
        {
            dialogueTriggered = true;
            dialoguePanel.SetActive(true);
            dialogueSystem.ProgressDialogue();

            if (gameObject.CompareTag("BadNPC"))
            {
                Lvl2_Score.lives--;
                Lvl4_Score.lives--;
            }
            else
            {
                // Start the dialogue with the NPC using the DialogueSystem
            }
        }

        // Allow interaction if dialogue has ended and player re-enters the NPC's hitbox
        if (dialogueEnded && playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            dialogueEnded = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && dialogueTriggered && !dialogueEnded)
        {
            dialogueSystem.ProgressDialogue();

            // Check if the dialogue has ended
            if (!dialoguePanel.activeSelf)
            {
                dialogueEnded = true;
            }
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueTriggered = false;
    }
}

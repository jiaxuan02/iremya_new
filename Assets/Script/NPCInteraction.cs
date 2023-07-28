using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogueSystem dialogueSystem; // Reference to the DialogueSystem script on the NPC
    public GameObject dialoguePanel; // Reference to the GameObject representing the dialogue panel
    public GameObject interactionPrompt; // Reference to the GameObject representing the interaction prompt

    private bool playerInRange = false; // Flag to track if the player is in range for interaction
    private bool dialogueTriggered = false; // Flag to track if the dialogue has been triggered

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player's hitbox (tag: "Player") entered the NPC's trigger collider
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            // Show the interaction prompt
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player's hitbox (tag: "Player") exited the NPC's trigger collider
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // Hide the interaction prompt
            interactionPrompt.SetActive(false);

            // Reset the dialogue trigger flag when the player moves away from the NPC
            dialogueTriggered = false;
        }
    }

    private void Update()
    {
        // Check if the player presses the "F" key to interact with the NPC
        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !dialogueTriggered)
        {
            // Disable the "F" key so it can't be used again to trigger the dialogue
            dialogueTriggered = true;

            // Show the dialogue panel before starting the dialogue
            dialoguePanel.SetActive(true);
            dialogueSystem.ProgressDialogue();

            // Check if the NPC has the "BadNPC" tag
            if (gameObject.CompareTag("BadNPC"))
            {
                // Decrease the player's lives by 1
                Lvl2_Score.lives--;
            }
            else
            {
                // Start the dialogue with the NPC using the DialogueSystem
             
            }
        }

        // Check if the player presses the "E" key to progress the dialogue
        if (Input.GetKeyDown(KeyCode.E) && dialogueTriggered)
        {
            // Continue the dialogue using the DialogueSystem
            dialogueSystem.ProgressDialogue();
        }
    }

    // Method to be called from the DialogueSystem when the dialogue ends
    public void EndDialogue()
    {
        // Hide the dialogue panel when the dialogue ends
        dialoguePanel.SetActive(false);

        // Reset the dialogueTriggered flag to allow interaction with NPCs again
        dialogueTriggered = false;
    }
}

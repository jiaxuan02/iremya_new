using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogueSet
{
    public DialogueLine[] dialogueLines;
}

[System.Serializable]
public class DialogueLine
{
    public string dialogueText;
    public AudioClip voiceClip; // Add an AudioClip field for voice clip
    public GameObject[] objectsToHide;
    public GameObject[] objectsToShow;
    public bool hideObjectsOnStart;
    public bool showObjectsOnStart;
}

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;
    public TextMeshProUGUI dialogueTextMeshPro;
    public Button continueButton;
    public AudioSource voiceSource; // Reference to an AudioSource component to play voice clips
    public DialogueSet[] dialogueSets;
    public GameObject dialoguePanel; // Reference to the GameObject representing the dialogue panel

    private int currentSetIndex = 0;
    private int currentLineIndex = 0;
    private bool useTextMeshPro;
    private bool dialogueInProgress = false;

    private PlayerMovement playerMovement; // Reference to the PlayerMovement script on the player

    private void Start()
    {
        if (dialogueSets.Length == 0)
        {
            Debug.LogError("No dialogue sets defined!");
            return;
        }

        // Check if TextMeshPro is available and should be used
        useTextMeshPro = dialogueTextMeshPro != null;

        // Set the initial dialogue text
        UpdateDialogueText();

        // Attach the button click event
        continueButton.onClick.AddListener(ProgressDialogue);

        // Get the PlayerMovement component from the player
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void ProgressDialogue()
    {
        if (!dialogueInProgress) // Prevent multiple clicks while dialogue is in progress
        {
            dialogueInProgress = true;

            DialogueSet currentSet = dialogueSets[currentSetIndex];
            if (currentLineIndex < currentSet.dialogueLines.Length - 1) // Adjusted condition here
            {
                DialogueLine currentLine = currentSet.dialogueLines[currentLineIndex];

                // Play the voice clip, if available
                if (currentLine.voiceClip != null && voiceSource != null)
                {
                    voiceSource.clip = currentLine.voiceClip;
                    voiceSource.Play();
                }

                // Hide or show objects after dialogue
                HideObjects(currentLine.objectsToHide);
                ShowObjects(currentLine.objectsToShow);

                // Increase the current line index
                currentLineIndex++;

                // Update the dialogue text
                UpdateDialogueText();
            }
            else
            {
                // Dialogue has ended, close the dialogue panel
                CloseDialoguePanel();
            }

            dialogueInProgress = false;
        }
    }

    private void UpdateDialogueText()
    {
        DialogueSet currentSet = dialogueSets[currentSetIndex];
        if (currentLineIndex < currentSet.dialogueLines.Length)
        {
            DialogueLine currentLine = currentSet.dialogueLines[currentLineIndex];
            string dialogue = currentLine.dialogueText;

            if (useTextMeshPro)
            {
                dialogueTextMeshPro.text = dialogue;
            }
            else
            {
                dialogueText.text = dialogue;
            }
        }
    }

    private void HideObjects(GameObject[] objectsToHide)
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    private void ShowObjects(GameObject[] objectsToShow)
    {
        foreach (GameObject obj in objectsToShow)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    private void CloseDialoguePanel()
    {
        // Hide the dialogue panel
        dialoguePanel.SetActive(false);

        // Reset the currentSetIndex and currentLineIndex when the dialogue ends
        currentSetIndex = 0;
        currentLineIndex = 0;

        // Call the EndDialogue method on the NPCInteraction script (if it exists)
        NPCInteraction npcInteraction = GetComponent<NPCInteraction>();
        if (npcInteraction != null)
        {
            npcInteraction.EndDialogue();
        }
        
        // Re-enable movement controls after the dialogue ends
        playerMovement.SetInDialogue(false);
    }
}

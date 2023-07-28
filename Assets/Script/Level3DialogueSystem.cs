using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Level3DialogueSet
{
    public Level3DialogueLine[] dialogueLines;
}

[System.Serializable]
public class Level3DialogueLine
{
    public string dialogueText;
    public AudioClip voiceClip; // Add an AudioClip field for voice clip
    public GameObject[] objectsToHide;
    public GameObject[] objectsToShow;
    public bool hideObjectsOnStart;
    public bool showObjectsOnStart;
}

public class Level3DialogueSystem : MonoBehaviour
{
    public Text dialogueTextLevel3;
    public TextMeshProUGUI dialogueTextMeshProLevel3;
    public Button continueButtonLevel3;
    public AudioSource voiceSourceLevel3; // Reference to an AudioSource component to play voice clips
    public Level3DialogueSet[] dialogueSetsLevel3;
    public GameObject dialoguePanelLevel3; // Reference to the GameObject representing the dialogue panel

    public AudioClip sceneStartAudioClip; // Audio clip to play on scene start

    private int currentSetIndexLevel3 = 0;
    private int currentLineIndexLevel3 = 0;
    private bool useTextMeshProLevel3;
    private bool dialogueInProgressLevel3 = false;

    private PlayerMovement playerMovementLevel3; // Reference to the PlayerMovement script on the player

    private void Awake()
    {
        // Check if TextMeshPro is available and should be used
        useTextMeshProLevel3 = dialogueTextMeshProLevel3 != null;

        // Play the scene start audio clip, if available
        if (sceneStartAudioClip != null && voiceSourceLevel3 != null)
        {
            voiceSourceLevel3.clip = sceneStartAudioClip;
            voiceSourceLevel3.Play();
        }
    }

    private void Start()
    {
        if (dialogueSetsLevel3.Length == 0)
        {
            Debug.LogError("No dialogue sets defined!");
            return;
        }

        // Set the initial dialogue text
        UpdateLevel3DialogueText();

        // Attach the button click event
        continueButtonLevel3.onClick.AddListener(ProgressLevel3Dialogue);

        // Get the PlayerMovement component from the player
        playerMovementLevel3 = FindObjectOfType<PlayerMovement>();
    }

    public void ProgressLevel3Dialogue()
    {
        if (!dialogueInProgressLevel3) // Prevent multiple clicks while dialogue is in progress
        {
            dialogueInProgressLevel3 = true;

            Level3DialogueSet currentSetLevel3 = dialogueSetsLevel3[currentSetIndexLevel3];
            if (currentLineIndexLevel3 < currentSetLevel3.dialogueLines.Length - 1) // Adjusted condition here
            {
                Level3DialogueLine currentLineLevel3 = currentSetLevel3.dialogueLines[currentLineIndexLevel3];

                // Play the voice clip, if available
                if (currentLineLevel3.voiceClip != null && voiceSourceLevel3 != null)
                {
                    voiceSourceLevel3.clip = currentLineLevel3.voiceClip;
                    voiceSourceLevel3.Play();
                }

                // Hide or show objects after dialogue
                HideLevel3Objects(currentLineLevel3.objectsToHide);
                ShowLevel3Objects(currentLineLevel3.objectsToShow);

                // Increase the current line index
                currentLineIndexLevel3++;

                // Update the dialogue text
                UpdateLevel3DialogueText();
            }
            else
            {
                // Dialogue has ended, close the dialogue panel
                CloseLevel3DialoguePanel();
            }

            dialogueInProgressLevel3 = false;
        }
    }

    private void UpdateLevel3DialogueText()
    {
        Level3DialogueSet currentSetLevel3 = dialogueSetsLevel3[currentSetIndexLevel3];
        if (currentLineIndexLevel3 < currentSetLevel3.dialogueLines.Length)
        {
            Level3DialogueLine currentLineLevel3 = currentSetLevel3.dialogueLines[currentLineIndexLevel3];
            string dialogueLevel3 = currentLineLevel3.dialogueText;

            if (useTextMeshProLevel3)
            {
                dialogueTextMeshProLevel3.text = dialogueLevel3;
            }
            else
            {
                dialogueTextLevel3.text = dialogueLevel3;
            }
        }
    }

    private void HideLevel3Objects(GameObject[] objectsToHide)
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    private void ShowLevel3Objects(GameObject[] objectsToShow)
    {
        foreach (GameObject obj in objectsToShow)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    private void CloseLevel3DialoguePanel()
    {
        // Hide the dialogue panel
        dialoguePanelLevel3.SetActive(false);

        // Reset the currentSetIndex and currentLineIndex when the dialogue ends
        currentSetIndexLevel3 = 0;
        currentLineIndexLevel3 = 0;

        // Call the EndDialogue method on the NPCInteraction script (if it exists)
        NPCInteraction npcInteractionLevel3 = GetComponent<NPCInteraction>();
        if (npcInteractionLevel3 != null)
        {
            npcInteractionLevel3.EndDialogue();
        }
        
        // Re-enable movement controls after the dialogue ends
        playerMovementLevel3.SetInDialogue(false);
    }
}

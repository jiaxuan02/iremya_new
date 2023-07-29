using UnityEngine;
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
    public Text dialogueText;
    public TextMeshProUGUI dialogueTextMeshPro;
    public Button continueButton;
    public AudioSource voiceSource; // Reference to an AudioSource component to play voice clips
    public Level3DialogueSet[] dialogueSets;
    private int currentSetIndex = 0;
    private int currentLineIndex = 0;
    private bool useTextMeshPro;

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
        continueButton.onClick.AddListener(ProgressLevel3Dialogue);
    }

    private void Update()
    {
        // Empty function
        
    }

    private void ProgressLevel3Dialogue()
    {
        Level3DialogueSet currentSet = dialogueSets[currentSetIndex];
        Level3DialogueLine currentLine = currentSet.dialogueLines[currentLineIndex];

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

        // Check if the dialogue set has reached the end
        if (currentLineIndex >= currentSet.dialogueLines.Length)
        {
            // Check if there are more dialogue sets
            if (currentSetIndex + 1 < dialogueSets.Length)
            {
                // Move to the next dialogue set
                currentSetIndex++;
                currentLineIndex = 0;
                UpdateDialogueText();
            }
            else
            {
                // Dialogue has ended, you can perform any necessary actions here
                Debug.Log("Dialogue Ended");
                // Hide or show objects after the final dialogue set if needed
                HideOrShowObjectsAfterLevel3Dialogue();
            }
        }
        else
        {
            // Update the dialogue text
            UpdateDialogueText();
        }
    }

    private void UpdateDialogueText()
    {
        Level3DialogueSet currentSet = dialogueSets[currentSetIndex];
        Level3DialogueLine currentLine = currentSet.dialogueLines[currentLineIndex];
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

    private void HideOrShowObjectsAfterLevel3Dialogue()
    {
        Level3DialogueSet currentSet = dialogueSets[currentSetIndex];
        Level3DialogueLine lastLine = currentSet.dialogueLines[currentSet.dialogueLines.Length - 1];

        // Hide or show objects after the final dialogue set if needed
        HideObjects(lastLine.objectsToHide);
        ShowObjects(lastLine.objectsToShow);
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
}

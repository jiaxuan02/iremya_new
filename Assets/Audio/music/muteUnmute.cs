using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteUnmute : MonoBehaviour
{
    public Sprite firstButtonImage; // The first image sprite
    public Sprite secondButtonImage; // The second image sprite
    public Button button;

    private bool isOn = true; // Keep track of the current image state
    public AudioSource audioSource;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked()
    {
        // Check the current image state and switch to the appropriate sprite
        if (isOn == true)
        {
            button.image.sprite = firstButtonImage;
            isOn = false;
            audioSource.mute = false;
        }
        else
        {
            button.image.sprite = secondButtonImage;
            isOn = true;
            audioSource.mute = true;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonSound : MonoBehaviour
{
    public Button button;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the button's onClick event to call the ButtonClicked method
        button.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked()
    {
        // Play the sound
        audioSource.Play();
    }
}

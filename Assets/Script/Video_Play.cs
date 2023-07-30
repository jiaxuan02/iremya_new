using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_Play : MonoBehaviour
{
    [SerializeField] private GameObject vid1;
    [SerializeField] private GameObject vid2;
    [SerializeField] private GameObject btn1;
    [SerializeField] private GameObject btn2;
    [SerializeField] private GameObject bg;

    private bool isVid2Activated = false;
    private bool isBgActivated = true;

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate vid2 at the beginning
        vid2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButton1Click()
    {
        // Activate vid2 when btn1 is clicked
        isVid2Activated = true;
        vid2.SetActive(true);
        // Optionally, deactivate vid1 if needed
        vid1.SetActive(false);
    }

    public void OnButton2Click()
    {
        // Activate vid2 when btn1 is clicked
        isBgActivated = false;
        bg.SetActive(false);
    }
}

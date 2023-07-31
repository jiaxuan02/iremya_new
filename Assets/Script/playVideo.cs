using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVideo : MonoBehaviour
{
    public GameObject button; // Assign this in the Inspector
    
    // Start is called before the first frame update
    void Start()
    {
       
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick2()
    {
        button.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    [SerializeField] private GameObject blur;

    [SerializeField] private TextAsset ink;
    public void Awake() {
        blur.SetActive(true);
        Time.timeScale = 0;
        DialogueManager.GetInstance().EnterDialogueMode(ink);
        Time.timeScale = 1;
    }

}

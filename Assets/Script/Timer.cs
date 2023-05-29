using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject losepanel;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float duration, currentTime;

    void Start() {
        losepanel.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    void Update() {
    }

    IEnumerator TimeIEn(){
        while(currentTime >= 0){
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }   
        OpenPanel();
    }

    void OpenPanel()
    {
        timeText.text = "";
        losepanel.SetActive(true);
    }
}

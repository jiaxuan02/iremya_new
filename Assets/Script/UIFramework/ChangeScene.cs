using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit(){
        SceneManager.LoadScene(1);
    }

    public void pauseGame(){
        Time.timeScale = 0;
    }

    public void startGame(){
        Time.timeScale = 1;
    }

    public void QuitGame(){
        Application.Quit();
    }
}

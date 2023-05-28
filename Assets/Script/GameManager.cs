using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int coins, winsConditions = 1;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            DestroyImmediate(this);
        } 
    }

    private static GameManager instance;

    public static GameManager MyInstance{
        get{
            if(instance == null)
                instance = new GameManager();

            return instance;
        }
    }

    private void Start() {
        UIManager.MyInstance.UpdateCoinUI(coins, winsConditions);
    }

    public void AddCoins(int _coins){
        coins += _coins;
        UIManager.MyInstance.UpdateCoinUI(coins, winsConditions);
    }
}

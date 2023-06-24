using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelManager : MonoBehaviour
{
    public static PlayerLevelManager Instance;
    public int scoreGame;

    void Awake(){
        Instance = this;
 
    }
    public bool TrySelectItem(int moneyToRemove){
        if(scoreGame >= moneyToRemove){
            scoreGame -= moneyToRemove;
            return true;
        }
        else{
            return false;
        }
    }
}

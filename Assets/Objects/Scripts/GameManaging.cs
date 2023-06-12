using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaging : MonoBehaviour
{
    public static int o2;
    public static int multiplier;

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            PlayerPrefs.DeleteAll();
        }
        if(o2 <= 0){
            o2 = 0;
        }
    }
}

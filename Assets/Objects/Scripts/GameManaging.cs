using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaging : MonoBehaviour
{
    public static int o2;
    public static int multiplier;
    public Transform startPosition;



    void Start()
    {
        float px = PlayerPrefs.GetFloat("LocationX");
        float py = PlayerPrefs.GetFloat("LocationY");
        
        startPosition.transform.position = new Vector3(px,py, -10);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            PlayerPrefs.DeleteAll();
        }
        if(o2 <= 0){
            o2 = 0;
        }
    }
}

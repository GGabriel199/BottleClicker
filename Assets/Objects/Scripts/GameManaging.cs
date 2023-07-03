using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaging : MonoBehaviour
{
    //Background properties
    public static int o2;
    public static int multiplier;
    public Transform startPosition;

    //Skin properties
    public static GameObject sr;
    private int selectedSprite;
    public GameObject[] selectedPrefab;  

    void Start()
    {
        //Background
        float px = PlayerPrefs.GetFloat("LocationX");
        float py = PlayerPrefs.GetFloat("LocationY", 50);
        
        startPosition.transform.position = new Vector3(px,py, -10);
        /*--------------------------x-------------------------------*/
        //Skins
        if(PlayerPrefs.HasKey("SelectedSprite")){
            selectedSprite = PlayerPrefs.GetInt("SelectedSprite");
            sr = Instantiate(selectedPrefab[selectedSprite]) as GameObject;
            sr.transform.SetParent(transform);
            sr.SetActive(true);
        }
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

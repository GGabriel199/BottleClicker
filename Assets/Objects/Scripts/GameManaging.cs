using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManaging : MonoBehaviour
{
    //Cash properties
    public static int o2;
    public static int multiplier;
    public static int goldenO2;
    public Transform startPosition;
    public TextMeshProUGUI gbTxt;
    //Skin properties
    public static GameObject sr;
    private int selectedSprite;
    public GameObject[] selectedPrefab;  

    void Start()
    {
        goldenO2 = PlayerPrefs.GetInt("GoldenBottle");
        gbTxt.text = "x" + goldenO2.ToString();

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

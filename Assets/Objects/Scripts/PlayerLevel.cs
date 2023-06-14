using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public int level;
    public Button[] levelButton;
    public Button[] backGroundBtn;
    public TextMeshProUGUI txtLevel;
    public Animator popUp;

    public Sprite[] bottle;

    private void Start()
    {
        level = PlayerPrefs.GetInt("PlayerLevel", 1);
    }

    private void Update()
    {
        txtLevel.text = "Level: " + level.ToString();
    }

    public void LevelUp()
    {
        if(level >= 1){
            levelButton[0].interactable = true;
            FindObjectOfType<ChangeSkin>().JuiceSkin();
        }
        if(level >= 2){
            levelButton[1].interactable = true;
            backGroundBtn[0].interactable = true;
            FindObjectOfType<ChangeSkin>().Coffee();
        }
        if(level >= 3){
            levelButton[2].interactable = true;
            backGroundBtn[1].interactable = true;
        }
        if(level >= 4){
            levelButton[3].interactable = true;
        }
        if(level >= 5){
            levelButton[4].interactable = true;
        }
        popUp.Play("LevelUp");
        GameManaging.multiplier = 1;
        GameManaging.o2 = 0;
        FindObjectOfType<SoundManager>().Play("LevelUp");
        PlayerPrefs.SetInt("PlayerLevel", level);
        level++;
    }
}

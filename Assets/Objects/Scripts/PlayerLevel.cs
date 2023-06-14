using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    private int level;
    public Button[] levelButton;
    public Button[] backGroundBtn;
    public TextMeshProUGUI txtLevel;
    public Animator popUp;
    public Animator labelSkin;
    public Animator labelBackground;
    public GameObject[] label;

    private void Start()
    {
        level = PlayerPrefs.GetInt("PlayerLevel", 1);
    }

    private void Update()
    {
        txtLevel.text = "Level: " + level.ToString();
        CheckLevel();
    }

    public void LevelUp()
    {
        popUp.Play("LevelUp");
        label[0].SetActive(true);
        label[1].SetActive(true);
        GameManaging.multiplier = 1;
        GameManaging.o2 = 0;
        FindObjectOfType<SoundManager>().Play("LevelUp");
        level++;
        PlayerPrefs.SetInt("PlayerLevel", level);
        labelSkin.Play("New Skin");
        labelBackground.Play("New Background");
    }

    public void CheckLevel(){
        if(level > 1){
            levelButton[0].interactable = true;
        }
        if(level > 2){
            levelButton[1].interactable = true;
            backGroundBtn[0].interactable = true;
        }
        if(level > 3){
            levelButton[2].interactable = true;
            backGroundBtn[1].interactable = true;
        }
        if(level > 4){
            levelButton[3].interactable = true;
        }
        if(level > 5){
            levelButton[4].interactable = true;
        }
    }
}

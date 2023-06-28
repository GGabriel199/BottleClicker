using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public static int level;
    public Button[] levelButton;
    public Button[] backGroundBtn;
    public TextMeshProUGUI txtLevel;
    public Animator popUp;
    public Animator labelSkin;
    public Animator labelBackground;
    public GameObject[] label;
    private bool newThings;
    public Button multiplierButton;

    private void Start()
    {
        FindObjectOfType<SoundManager>().Play("Main Theme");
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
        multiplierButton.interactable =true;
        label[0].SetActive(true);
        label[1].SetActive(true);
        GameManaging.multiplier = 1;
        GameManaging.o2 = 0;
        FindObjectOfType<SoundManager>().Play("LevelUp");
        FindObjectOfType<Particles>().SoundAndEffects();
        level++;
        PlayerPrefs.SetInt("PlayerLevel", level);
        if(newThings != false){
            labelSkin.Play("New Skin");
            labelBackground.Play("New Background");
        }
        
    }

    public void CheckLevel(){
        if(level > 1){
            newThings = true;
            levelButton[0].interactable = true;
            backGroundBtn[0].interactable = true;
        }
        if(level > 2){
            newThings = true;
            levelButton[1].interactable = true;
            backGroundBtn[1].interactable = true;
        }
        if(level > 3){
            newThings = true;
            levelButton[2].interactable = true;
            backGroundBtn[2].interactable = true;
        }
        if(level > 4){
            newThings = true;
            levelButton[3].interactable = true;
        }
        if(level > 5){
            newThings = true;
            levelButton[4].interactable = true;
        }
        if(level > 6){
            newThings = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public static int level;
    public Button[] skinsBtn;
    public Button[] backGroundBtn;
    public Button[] hiringButton;
    public TextMeshProUGUI txtLevel;
    public TextMeshProUGUI[] lockedTxt;
    public Animator popUp;
    public Animator labelSkin;
    public Animator labelBackground;
    public Animator labelHired;
    public GameObject[] label;
    private bool newSkins;
    private bool newBackgrd;
    private bool newHired;
    private int randomNumber;
    public Button multiplierButton;
    public Image[] hiringImg;
    public Image[] skinImg;
    public Image[] backGrdImg;

    private void Start()
    { 
        level = PlayerPrefs.GetInt("PlayerLevel", 10);
    }

    private void Update()
    {
        txtLevel.text = "Level: " + level.ToString();
        CheckLevel();
        if(level == 2){
            GameManaging.goldenO2 += 1;
        }
        if(level == 5){
            GameManaging.goldenO2 += 2;
        }
        if(level == 10){
            GameManaging.goldenO2 += 6;
        }
    }

    public void Buttons(){
        for (int i = 0; i<lockedTxt.Length;i++){
            lockedTxt[i].text = "Locked";
        }
    }

    public void LevelUp()
    {
        popUp.Play("LevelUp");
        multiplierButton.interactable = true;
        for (int i = 0; i<label.Length;i++){
            label[i].SetActive(true);
        }
        GameManaging.multiplier = 1;
        GameManaging.o2 = 0;
        PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        FindObjectOfType<SoundManager>().Play("LevelUp");
        FindObjectOfType<Particles>().StopParticles();
        level++;
        PlayerPrefs.SetInt("PlayerLevel", level);
        if(newSkins == true){
            labelSkin.Play("New Skin");
        }
        if(newBackgrd == true){
            labelBackground.Play("New Background");
        }
        if(newHired == true){
            labelHired.Play("LabelHired");
        }
        
    }

    public void CheckLevel(){
        if(level > 1){
            newSkins = true;
            newHired = true;
            newBackgrd = true;
            hiringButton[0].interactable = true;
            skinsBtn[0].interactable = true;
            backGroundBtn[0].interactable = true;
            hiringImg[0].color = new Color (255, 255, 255);
            skinImg[0].color = new Color (255, 255, 255);
            backGrdImg[0].color = new Color (255, 255, 255);
        }
        if(level > 2){
            newSkins = true;
            newBackgrd = false;
            newHired = false;
            skinsBtn[1].interactable = true;
            skinImg[1].color = new Color (255, 255, 255);
        }
        if(level > 3){
            newSkins = false;
            newHired = true;
            newBackgrd = true;
            hiringImg[1].color = new Color (255, 255, 255);
            hiringButton[1].interactable = true;
            backGroundBtn[1].interactable = true;
            backGrdImg[1].color = new Color (255, 255, 255);
        }
        if(level > 4){
            newSkins = true;
            newBackgrd = false;
            newHired = false;
            skinsBtn[2].interactable = true;
            skinImg[2].color = new Color (255, 255, 255);
        }
        if(level > 5){
            newSkins = false;
            newBackgrd = false;
            newHired = true;
            hiringImg[2].color = new Color (255, 255, 255);
            hiringButton[2].interactable = true;
        }
        if(level > 6){
            newSkins = true;
            newHired = false;
            newBackgrd = true;
            skinsBtn[3].interactable = true;
            backGroundBtn[2].interactable = true;
            skinImg[3].color = new Color (255, 255, 255);
            backGrdImg[2].color = new Color (255, 255, 255);
        }
        if(level > 7){
            newHired = true;
            newBackgrd = false;
            newSkins = false;
            hiringImg[3].color = new Color (255, 255, 255);
            hiringButton[3].interactable = true;
        }
        if(level > 8){
            newSkins = false;
            newBackgrd = false;
            newHired = false;
        }
        if(level > 9){
            newSkins = true;
            newBackgrd = false;
            newHired = false;
            skinsBtn[4].interactable = true;
            skinImg[4].color = new Color (255, 255, 255);
        }
        if(level > 10){
            newSkins = false;
        }
    }
}

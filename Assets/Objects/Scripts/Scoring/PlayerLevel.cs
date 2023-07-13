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
    public GameObject labelSkin;
    public GameObject labelBackground;
    public GameObject labelHired;
    public GameObject[] label;
    public TextMeshProUGUI gbTxt;
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
        level = PlayerPrefs.GetInt("PlayerLevel", 1);
    }

    private void Update()
    {
        txtLevel.text = "Level: " + level.ToString();
        gbTxt.text = GameManaging.goldenO2.ToString();
        CheckLevel();
        AnimationLabel();
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
        GameManaging.goldenO2 += 1;
        PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        FindObjectOfType<SoundManager>().Play("LevelUp");
        FindObjectOfType<Particles>().StopParticles();
        level++;
        PlayerPrefs.SetInt("PlayerLevel", level);
        if(newSkins != false){
            labelSkin.SetActive(true);
        }
        else{
            labelSkin.SetActive(false);
        }
        if(newBackgrd != false){
            labelBackground.SetActive(true);
        }
        else{
            labelBackground.SetActive(false);
        }
        if(newHired != false){
            labelHired.SetActive(true);
        }
        else{
            labelHired.SetActive(false);
        }
        
    }

    private void CheckLevel(){
        if(level > 1){
            hiringButton[0].interactable = true;
            skinsBtn[0].interactable = true;
            backGroundBtn[0].interactable = true;
            hiringImg[0].color = new Color (255, 255, 255);
            skinImg[0].color = new Color (255, 255, 255);
            backGrdImg[0].color = new Color (255, 255, 255);
        }
        if(level > 3){
            hiringImg[1].color = new Color (255, 255, 255);
            hiringButton[1].interactable = true;
            backGroundBtn[1].interactable = true;
            backGrdImg[1].color = new Color (255, 255, 255);
        }
        if(level > 4){
            skinsBtn[1].interactable = true;
            skinImg[1].color = new Color (255, 255, 255);
        }
        if(level > 5){
            hiringImg[2].color = new Color (255, 255, 255);
            hiringButton[2].interactable = true;
            skinsBtn[2].interactable = true;
            skinImg[2].color = new Color (255, 255, 255);
        }
        if(level > 6){
            skinsBtn[3].interactable = true;
            skinImg[3].color = new Color (255, 255, 255);
        }
        if(level > 7){
            hiringImg[3].color = new Color (255, 255, 255);
            hiringButton[3].interactable = true;
            backGroundBtn[2].interactable = true;
            backGrdImg[2].color = new Color (255, 255, 255);
        }
        if(level > 9){
            skinsBtn[4].interactable = true;
            skinImg[4].color = new Color (255, 255, 255);
        }
        if(level > 10){
            backGrdImg[3].color = new Color (255, 255, 255);
            backGroundBtn[3].interactable = true;
        }
    }

    private void AnimationLabel(){
        if(level == 1){
            newSkins = true;
            newHired = true;
            newBackgrd = true;
        }
        if(level == 2){
            newSkins = false;
            newBackgrd = false;
            newHired = false;
        }
        if(level == 3){
            newSkins = false;
            newHired = true;
            newBackgrd = true;
        }
        if(level == 4){
            newSkins = true;
            newBackgrd = false;
            newHired = false;
        }
        if(level == 5){
            newSkins = true;
            newBackgrd = false;
            newHired = true;
        }
        if(level == 6){
            newSkins = true;
            newHired = false;
            newBackgrd = false;
        }
        if(level == 7){
            newHired = true;
            newBackgrd = true;
            newSkins = false;
        }
        if(level == 8){
            newSkins = false;
            newBackgrd = false;
            newHired = false;
        }
        if(level == 9){
            newSkins = true;
            newBackgrd = false;
            newHired = false;
        }
        if(level == 10){
            newSkins = false;
            newBackgrd = true;
            newHired = false;
        }
        if(level == 11){
            newSkins = false;
            newBackgrd = false;
            newHired = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAndClicks : MonoBehaviour
{
    private int maxValue;
    public int[] cost;
    private int pressed = 1;
    public Button button;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI clicksText;
    public TextMeshProUGUI clicksTextShop;
    public TextMeshProUGUI[] costText;
    public TextMeshProUGUI maxValueTxt;
    private Animator anim;
    private int selectedSprite;

    void Awake(){
        LoadData();
    }
    void Start()
    {
        if(PlayerPrefs.HasKey("SelectedSprite")){
            selectedSprite = PlayerPrefs.GetInt("SelectedSprite");
            anim = GetComponent<Animator>();
        }
        
        
        FindObjectOfType<Particles>().SoundAndEffects();
    }

    private void Update()
    {
        clicksText.text = "Clicks: " + GameManaging.o2;
        clicksTextShop.text = "$" + GameManaging.o2;
        maxValueTxt.text = "Max Value: " + maxValue.ToString();
        Cost();
    }

    private void LoadData(){
        GameManaging.multiplier = PlayerPrefs.GetInt("prefMoney", 1);
        GameManaging.o2 = PlayerPrefs.GetInt("o2", 0);
        maxValue = PlayerPrefs.GetInt("maxValue", 1000000);
        cost[0] = PlayerPrefs.GetInt("costSoda", 50);
        cost[1] = PlayerPrefs.GetInt("costWine", 150);
        cost[2] = PlayerPrefs.GetInt("costChoppMachine", 1200);
        cost[3] = PlayerPrefs.GetInt("costMultiplier", maxValue /2);
    }

    public void PlusClicks()
    {
        GameManaging.o2 += GameManaging.multiplier;
        ClickSound();
        anim.Play("Press");
        pressed = Random.Range(1,4);
        PlayerPrefs.SetInt("o2", GameManaging.o2);
        if (GameManaging.o2 >= maxValue)
        {
            maxValue += maxValue * 1/5;
            FindObjectOfType<PlayerLevel>().LevelUp();
            PlayerPrefs.SetInt("maxValue", maxValue);
        }
    }

    public void ClickSound(){
        if(pressed == 1){
            FindObjectOfType<SoundManager>().Play("BottleClick");
        }
        if(pressed == 2){
            FindObjectOfType<SoundManager>().Play("BottleClick2");
        }
        if(pressed == 3){
            FindObjectOfType<SoundManager>().Play("BottleClick3");
        }
    }

    public void Shop1(int amount)
    {
        if(amount == 1 && GameManaging.o2 >= cost[0]){
            cost[0] += cost[0]*1/20;
            GameManaging.multiplier += 1;
            GameManaging.o2 -=cost[0];
            FindObjectOfType<SoundManager>().Play("Click");
            PlayerPrefs.SetInt("costSoda", cost[0]);
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        }
        if(amount == 2 && GameManaging.o2 >= cost[1]){
            cost[1] += cost[1]*1/20;;
            GameManaging.multiplier += 5;
            GameManaging.o2 -=cost[1];
            FindObjectOfType<SoundManager>().Play("Click");
            PlayerPrefs.SetInt("costWine", cost[1]);
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        }
        if(amount == 3 && GameManaging.o2 >= cost[2]){
            cost[2] += cost[2]*1/20;
            GameManaging.multiplier += 20;
            GameManaging.o2 -= cost[2];
            FindObjectOfType<SoundManager>().Play("Click");
            PlayerPrefs.SetInt("costChoppMachine", cost[2]);
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        }
        if(amount == 4 && GameManaging.o2 >= cost[3]){
            GameManaging.multiplier = GameManaging.multiplier *2;
            GameManaging.o2 -= cost[3];
            FindObjectOfType<SoundManager>().Play("MultiplierClick");
            PlayerPrefs.SetInt("costMultiplier", GameManaging.o2);
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
            button.interactable = false;
        }
    }

    public void Cost(){
        costText[0].text = "$" + cost[0];
        costText[1].text = "$" + cost[1];
        costText[2].text = "$" + cost[2];
        costText[3].text = "$" + cost[3];
    }
}
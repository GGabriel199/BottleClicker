using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAndClicks : MonoBehaviour
{
    private int maxValue = 1000000;
    public int[] cost;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI clicksText;
    public TextMeshProUGUI clicksTextShop;
    public TextMeshProUGUI[] costText;
    public TextMeshProUGUI maxValueTxt;
    public Animator anim;

    public GameObject bottle;

    void Start()
    {
        GameManaging.multiplier = PlayerPrefs.GetInt("prefMoney", 1);
        GameManaging.o2 = PlayerPrefs.GetInt("o2", 0);
    }

    private void Update()
    {
        clicksText.text = "Clicks: " + GameManaging.o2;
        clicksTextShop.text = "$ " + GameManaging.o2;
        maxValueTxt.text = "Max Value: " + maxValue.ToString();
        Cost();
    }

    public void PlusClicks()
    {
        GameManaging.o2 += GameManaging.multiplier;
        FindObjectOfType<SoundManager>().Play("BottleClick");
        anim.Play("Bottle");
        PlayerPrefs.SetInt("o2", GameManaging.o2);
        if (GameManaging.o2 >= maxValue)
        {
            maxValue += maxValue * 1/5;
            FindObjectOfType<PlayerLevel>().LevelUp();
        }
    }

    public void Shop1(int amount)
    {
        if(amount == 1 && GameManaging.o2 >= cost[0]){
            cost[0] += cost[0]*1/20;
            GameManaging.multiplier += 1;
            GameManaging.o2 -=50;
            FindObjectOfType<SoundManager>().Play("Click");
            PlayerPrefs.SetInt("cost",cost[0]);
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        }
        if(amount == 2 && GameManaging.o2 >= cost[1]){
            cost[1] += cost[1]*1/20;;
            GameManaging.multiplier += 5;
            GameManaging.o2 -=150;
            FindObjectOfType<SoundManager>().Play("Click");
            PlayerPrefs.SetInt("cost",cost[1]);
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        }
        if(amount == 3 && GameManaging.o2 >= cost[2]){
            cost[2] += cost[2]*1/20;
            GameManaging.multiplier += 20;
            GameManaging.o2 -= 1200;
            FindObjectOfType<SoundManager>().Play("Click");
            PlayerPrefs.SetInt("cost",cost[2]);
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        }
    }

    public void Cost(){
        costText[0].text = "$" + cost[0];
        costText[1].text = "$" + cost[1];
        costText[2].text = "$" + cost[2];
    }
}
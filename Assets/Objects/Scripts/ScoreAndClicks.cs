using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAndClicks : MonoBehaviour
{
    private int maxValue = 1000000000;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI clicksText;
    public TextMeshProUGUI clicksTextShop;
    public Animator anim;

    public GameObject bottle;

    void Start()
    {
        GameManaging.multiplier = PlayerPrefs.GetInt("prefMoney");
    }

    private void Update()
    {
        clicksText.text = "Clicks: " + GameManaging.o2;
        clicksTextShop.text = "$ " + GameManaging.o2;
    }

    public void PlusClicks()
    {
        GameManaging.o2 += GameManaging.multiplier;
        FindObjectOfType<SoundManager>().Play("BottleClick");
        anim.Play("Bottle");
        PlayerPrefs.SetInt("o2", GameManaging.o2);
        if (GameManaging.multiplier >= maxValue)
        {
            GameManaging.multiplier = 0;
            FindObjectOfType<PlayerLevel>().LevelUp();
        }
    }

    public void Shop1(int amount)
    {
        if(amount == 1 && GameManaging.o2 >= 50){
            GameManaging.multiplier += 1;
            GameManaging.o2 -=50;
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        }
        if(amount == 2 && GameManaging.o2 >= 150){
            GameManaging.multiplier += 5;
            GameManaging.o2 -=150;
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        }
        if(amount == 3 && GameManaging.o2 >= 1200){
            GameManaging.multiplier += 20;
            GameManaging.o2 -= 1200;
            PlayerPrefs.SetInt("o2", GameManaging.o2);
            PlayerPrefs.SetInt("prefMoney", GameManaging.multiplier);
        }
    }
}
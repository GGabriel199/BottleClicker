using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hiring : MonoBehaviour
{
    public float[] clickEvent;
    public float[] startTime;
    private const float timerLimit = 0f;
    private bool bugBought;
    private bool gunBought;
    private bool springBought;
    public Animator[] anim;
    public Button[] button;
    public int[] price;
    public TextMeshProUGUI[] priceText;

    void Update()
    {
        Isbought();
    }

    //Hire Store information
    public void HiringShop(int value)
    {
        if(value == 1 && GameManaging.o2 >= price[0]){
            GameManaging.o2 -= price[0];
            bugBought = true;
            button[0].interactable = false;
            priceText[0].text = "Out Of Stock";
        }
        if(value == 2 && GameManaging.o2 >= price[1]){
            GameManaging.o2 -= price[1];
            gunBought = true;
            button[1].interactable = false;
            priceText[1].text = "Out Of Stock";
        }
        if(value == 3 && GameManaging.o2 >= price[2]){
            GameManaging.o2 -= price[2];
            springBought = true;
            button[2].interactable = false;
            priceText[2].text = "Out Of Stock";
        }
    }

    void Isbought(){
        if(bugBought != true)
        {
            priceText[0].text = "Buy$:" + price[0].ToString();
        }
        else
        {
            startTime[0] -= Time.deltaTime;
            if(startTime[0]< timerLimit){
                StartCoroutine(Scoring(1));
                startTime[0] = 10f;
            }
        }
        if(gunBought != true)
        {
            priceText[1].text = "Buy$:" + price[1].ToString();
        }
        else
        {
            startTime[1] -= Time.deltaTime;
            if(startTime[1]< timerLimit){
                StartCoroutine(Scoring(2));
                startTime[1] = 15f;
            }
        }
        if(springBought != true)
        {
            priceText[2].text = "Buy$:" + price[2].ToString();
        }
        else
        {
            startTime[2] -= Time.deltaTime;
            if(startTime[2]< timerLimit){
                StartCoroutine(Scoring(3));
                startTime[2] = 6f;
            }
        }
    }

    IEnumerator Scoring(int value)
    {
        if(value == 1){
            anim[0].Play("JumpAndClick");

            yield return new WaitForSeconds(clickEvent[0]);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();

            yield break;
        }

        if(value == 2){
            anim[1].Play("PistolWater");

            yield return new WaitForSeconds(clickEvent[1]);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(clickEvent[1]);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(clickEvent[1]);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(clickEvent[1]);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(clickEvent[1]);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();

            yield break;
        }

        if(value == 3){
            anim[2].Play("springjump");

            yield return new WaitForSeconds(clickEvent[2]);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(clickEvent[2]);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();

            yield break;
        }
    }
}

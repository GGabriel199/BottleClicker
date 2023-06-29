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
    public List<Animator>anim = new List<Animator>();
    public Animator activeItem;
    public GameObject[] hired;
    public int[] price;
    private int selectedObject;
    public TextMeshProUGUI[] priceText;

    void Start(){
        if(PlayerPrefs.HasKey("SelectedHired"))
        {
            selectedObject = PlayerPrefs.GetInt("SelectedHired");
            activeItem = anim[selectedObject];
        }
    }
    void Update()
    {
        Isbought();
    }

    public void SaveObject(){
        PlayerPrefs.SetInt("SelectedHired", selectedObject);
        activeItem = anim[selectedObject];
    }
    
    //Hire Store information
    public void HiringShop(int value)
    {
        if(value == 1 && GameManaging.o2 >= price[0]){
            GameManaging.o2 -= price[0];
            bugBought = true;
            priceText[0].text = "Dismiss!";
            selectedObject = 0;
            SaveObject();
            hired[0].SetActive(true);
            Unhire(1, false);
            Unhire(2, true);
            Unhire(3, true);
        }
        if(value == 2 && GameManaging.o2 >= price[1]){
            GameManaging.o2 -= price[1];
            gunBought = true;
            priceText[1].text = "Dismiss!";
            selectedObject = 1;
            SaveObject();
            hired[1].SetActive(true);
            Unhire(1, true);
            Unhire(2, false);
            Unhire(3, true);
        }
        if(value == 3 && GameManaging.o2 >= price[2]){
            GameManaging.o2 -= price[2];
            springBought = true;
            priceText[2].text = "Dismiss!";
            selectedObject = 2;
            SaveObject();
            hired[2].SetActive(true);
            Unhire(1, true);
            Unhire(2, true);
            Unhire(3, false);
        }
    }

    void Isbought(){
        if(bugBought != true)
        {
            priceText[0].text = "Buy$" + price[0].ToString();
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
            priceText[1].text = "Buy$" + price[1].ToString();
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
            priceText[2].text = "Buy$" + price[2].ToString();
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

    public void Unhire(int value, bool pressed)
    {
        if(value == 1 && pressed == true){
            hired[0].SetActive(false);
            priceText[0].text = "Hire again$" + price[0].ToString();
        }
        else if(pressed == false){
            HiringShop(1);
        }
        if(value == 2 && pressed == true){
            hired[1].SetActive(false);
            priceText[1].text = "Hire again$" + price[1].ToString();
        }
        else if(pressed == false){
            HiringShop(2);
        }
        if(value == 3 && pressed == true){
            hired[2].SetActive(false);
            priceText[2].text = "Hire again$" + price[2].ToString();
        }
        else if(pressed == false){
            HiringShop(3);
        }
       
    }
}

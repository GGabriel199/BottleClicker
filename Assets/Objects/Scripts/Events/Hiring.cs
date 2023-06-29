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
    public Animator[] activeItem;
    public GameObject[] hiredOn;
    public GameObject[] hiredOff;
    public int[] price;
    private int selectedObject;
    public TextMeshProUGUI[] priceText;

    void Start(){
        LoadKeys();
    }
    void Update()
    {
        Isbought();
    }

    public void SaveObject(){
        PlayerPrefs.SetInt("SelectedHired", selectedObject);
        for (int i = 0; i < activeItem.Length; i++){
            activeItem[i] = anim[selectedObject];
        }
    }
    
    //Hire Store information
    public void HiringShop(int value)
    {
        if(value == 1 && GameManaging.o2 >= price[0] && bugBought == false){
            GameManaging.o2 -= price[0];
            bugBought = true;
            selectedObject = 0;
            SaveObject();
            hiredOn[0].SetActive(false);
            hiredOff[0].SetActive(true);
        }
        if(value == 2 && GameManaging.o2 >= price[1] && gunBought == false){
            GameManaging.o2 -= price[1];
            gunBought = true;
            selectedObject = 1;
            SaveObject();
            hiredOn[1].SetActive(false);
            hiredOff[1].SetActive(true);
        }
        if(value == 3 && GameManaging.o2 >= price[2] && springBought == false){
            GameManaging.o2 -= price[2];
            springBought = true;
            selectedObject = 2;
            SaveObject();
            hiredOn[2].SetActive(false);
            hiredOff[2].SetActive(true);
        }
    }

    void Isbought(){
        if(bugBought != true)
        {
            priceText[0].text = "Buy$" + price[0].ToString();
            hiredOn[0].SetActive(true);
            hiredOff[0].SetActive(false);
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
            hiredOn[1].SetActive(true);
            hiredOff[1].SetActive(false);
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
            hiredOn[2].SetActive(true);
            hiredOff[2].SetActive(false);
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
    public void Unhire(int value)
    {
        if(value == 1 && bugBought == true){
            hiredOn[0].SetActive(true);
            hiredOff[0].SetActive(false);
            StopCoroutine(Scoring(1));
            bugBought = false;
        }

        if(value == 2 && gunBought == true){
            hiredOn[1].SetActive(true);
            hiredOff[1].SetActive(false);
            StopCoroutine(Scoring(2));
            gunBought = false;
        }

        if(value == 3 && springBought == true){
            hiredOn[2].SetActive(true);
            hiredOff[2].SetActive(false);
            StopCoroutine(Scoring(3));
            springBought = false;
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

    void LoadKeys(){
        bugBought = PlayerPrefs.GetInt("BugBought") == 1;
        gunBought = PlayerPrefs.GetInt("GunBought") == 1;
        springBought = PlayerPrefs.GetInt("SpringBought") == 1;

        if(PlayerPrefs.HasKey("BugBought"))
        {
            bugBought = PlayerPrefs.GetInt("BugBought") == 1;
        }
        else{
            PlayerPrefs.SetInt("BugBought", 1);
            PlayerPrefs.SetInt("BugBought", bugBought ? 1 : 0);
        }

        if(PlayerPrefs.HasKey("GunBought"))
        {
            gunBought = PlayerPrefs.GetInt("GunBought") == 1;
        }
        else{
            PlayerPrefs.SetInt("GunBought", 1);
            PlayerPrefs.SetInt("GunBought", gunBought ? 1 : 0);
        }

        if(PlayerPrefs.HasKey("SpringBought"))
        {
            springBought = PlayerPrefs.GetInt("SpringBought") == 1;
        }
        else{
            PlayerPrefs.SetInt("SpringBought", 1);
            PlayerPrefs.SetInt("SpringBought", springBought ? 1 : 0);
        }
        if(PlayerPrefs.HasKey("SelectedHired"))
        {
            selectedObject = PlayerPrefs.GetInt("SelectedHired");
            for (int i = 0; i < activeItem.Length; i++){
                activeItem[i] = anim[selectedObject];
                }
            
        }
    }
}

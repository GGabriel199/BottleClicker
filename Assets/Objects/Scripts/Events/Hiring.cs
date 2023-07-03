using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hiring : MonoBehaviour
{
    [SerializeField] public float[] clickEvent;
    [SerializeField] public float[] startTime;
    private const float timerLimit = 0f;
    private bool bugBought;
    private bool gunBought;
    private bool springBought;
    
    [SerializeField] public Animator[] anim;
    [SerializeField] public int[] price;
    [SerializeField] public GameObject[] ar;
    [SerializeField] public int[] selectedObject;
    [SerializeField] public List<GameObject>animList = new List<GameObject>();
    [SerializeField] public GameObject[] hiredOn;
    [SerializeField] public GameObject[] hiredOff;
    [SerializeField] public Image[] items;
    [SerializeField] public TextMeshProUGUI[] priceText;

    void Start(){
        LoadKeys();
    }
    void Update()
    {
        Isbought();
    }
    
    //Hire Store information
    public void HiringShop(int value)
    {
        if(value == 1 && GameManaging.o2 >= price[0] && bugBought == false){
            GameManaging.o2 -= price[0];
            bugBought = true;
            selectedObject[0] = 1;
            items[0].color = new Color (255, 255, 255);
            ar[0] = animList[selectedObject[0]];
            hiredOn[0].SetActive(false);
            hiredOff[0].SetActive(true);
            PlayerPrefs.SetInt("BugBought", selectedObject[0]);
        }
        if(value == 2 && GameManaging.o2 >= price[1] && gunBought == false){
            GameManaging.o2 -= price[1];
            gunBought = true;
            selectedObject[1] = 1;
            items[1].color = new Color (255, 255, 255);
            ar[1] = animList[selectedObject[1]];
            hiredOn[1].SetActive(false);
            hiredOff[1].SetActive(true);
            PlayerPrefs.SetInt("GunBought", selectedObject[1]);
        }
        if(value == 3 && GameManaging.o2 >= price[2] && springBought == false){
            GameManaging.o2 -= price[2];
            springBought = true;
            items[2].color = new Color (255, 255, 255);
            ar[3] = animList[selectedObject[2]];
            selectedObject[2] = 1;
            hiredOn[2].SetActive(false);
            hiredOff[2].SetActive(true);
            PlayerPrefs.SetInt("SpringBought", selectedObject[2]);
        }
    }

    void LoadKeys(){
        selectedObject[0] = PlayerPrefs.GetInt("BugBought");
        selectedObject[1] = PlayerPrefs.GetInt("GunBought");
        selectedObject[2] = PlayerPrefs.GetInt("SpringBought");

        if(selectedObject[0] == 1)
        {
            ar[0] = animList[selectedObject[0]];
            bugBought = true;
        }

        if(selectedObject[1] == 1)
        {
            ar[1] = animList[selectedObject[1]];
            gunBought = true;
        }

        if(selectedObject[2] == 1)
        {
            ar[2] = animList[selectedObject[2]];
            springBought = true;
        } 
    }

    void Isbought(){
        if(bugBought != true)
        {
            priceText[0].text = "Buy$" + price[0].ToString();
            items[0].color = new Color (0, 0, 0);
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
            items[1].color = new Color (0, 0, 0);
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
            items[2].color = new Color (0, 0, 0);
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
            items[0].color = new Color (0, 0, 0);
            StopCoroutine(Scoring(1));
            bugBought = false;
            selectedObject [0] = 0;
            PlayerPrefs.SetInt("BugBought", selectedObject[0]);
        }

        if(value == 2 && gunBought == true){
            hiredOn[1].SetActive(true);
            hiredOff[1].SetActive(false);
            items[1].color = new Color (0, 0, 0);
            StopCoroutine(Scoring(2));
            gunBought = false;
            selectedObject [1] = 0;
            PlayerPrefs.SetInt("GunBought", selectedObject[1]);
        }

        if(value == 3 && springBought == true){
            hiredOn[2].SetActive(true);
            hiredOff[2].SetActive(false);
            items[2].color = new Color (0, 0, 0);
            StopCoroutine(Scoring(3));
            springBought = false;
            selectedObject [2] = 0;
            PlayerPrefs.SetInt("SpringBought", selectedObject[2]);
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

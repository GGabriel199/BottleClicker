using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hiring : MonoBehaviour
{
    [SerializeField] public float[] startTime;
    private const float timerLimit = 0f;
    private bool bugBought;
    private bool gunBought;
    private bool springBought;
    private bool bikerBought;
    
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
            FindObjectOfType<SoundManager>().Play("Bug");
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
            FindObjectOfType<SoundManager>().Play("Gun");
            PlayerPrefs.SetInt("GunBought", selectedObject[1]);
        }
        if(value == 3 && GameManaging.o2 >= price[2] && springBought == false){
            GameManaging.o2 -= price[2];
            springBought = true;
            items[2].color = new Color (255, 255, 255);
            ar[2] = animList[selectedObject[2]];
            selectedObject[2] = 1;
            hiredOn[2].SetActive(false);
            hiredOff[2].SetActive(true);
            FindObjectOfType<SoundManager>().Play("Spring");
            PlayerPrefs.SetInt("SpringBought", selectedObject[2]);
        }
        if(value == 4 && GameManaging.o2 >= price[3] && bikerBought == false){
            GameManaging.o2 -= price[3];
            bikerBought = true;
            items[3].color = new Color (255, 255, 255);
            ar[3] = animList[selectedObject[3]];
            selectedObject[3] = 1;
            hiredOn[3].SetActive(false);
            hiredOff[3].SetActive(true);
            FindObjectOfType<SoundManager>().Play("Bike");
            PlayerPrefs.SetInt("BikerBought", selectedObject[3]);
        }
    }

    void LoadKeys(){
        selectedObject[0] = PlayerPrefs.GetInt("BugBought");
        selectedObject[1] = PlayerPrefs.GetInt("GunBought");
        selectedObject[2] = PlayerPrefs.GetInt("SpringBought");
        selectedObject[3] = PlayerPrefs.GetInt("BikerBought");

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
        if(selectedObject[3] == 1)
        {
            ar[3] = animList[selectedObject[3]];
            bikerBought = true;
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
        if(bikerBought != true)
        {
            priceText[3].text = "Buy$" + price[3].ToString();
            items[3].color = new Color (0, 0, 0);
            hiredOn[3].SetActive(true);
            hiredOff[3].SetActive(false);
        }
        else
        {
            startTime[3] -= Time.deltaTime;
            if(startTime[3]< timerLimit){
                StartCoroutine(Scoring(4));
                startTime[3] = 8f;
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
            FindObjectOfType<SoundManager>().Play("Selected");
        }

        if(value == 2 && gunBought == true){
            hiredOn[1].SetActive(true);
            hiredOff[1].SetActive(false);
            items[1].color = new Color (0, 0, 0);
            StopCoroutine(Scoring(2));
            gunBought = false;
            selectedObject [1] = 0;
            PlayerPrefs.SetInt("GunBought", selectedObject[1]);
            FindObjectOfType<SoundManager>().Play("Selected");
        }

        if(value == 3 && springBought == true){
            hiredOn[2].SetActive(true);
            hiredOff[2].SetActive(false);
            items[2].color = new Color (0, 0, 0);
            StopCoroutine(Scoring(3));
            springBought = false;
            selectedObject [2] = 0;
            PlayerPrefs.SetInt("SpringBought", selectedObject[2]);
            FindObjectOfType<SoundManager>().Play("Selected");
        } 
        if(value == 4 && bikerBought == true){
            hiredOn[3].SetActive(true);
            hiredOff[3].SetActive(false);
            items[3].color = new Color (0, 0, 0);
            StopCoroutine(Scoring(4));
            springBought = false;
            selectedObject [3] = 0;
            PlayerPrefs.SetInt("BikerBought", selectedObject[3]);
            FindObjectOfType<SoundManager>().Play("Selected");
        } 
    }
    IEnumerator Scoring(int value)
    {
        if(value == 1){
            anim[0].Play("JumpAndClick");

            yield return new WaitForSeconds(0.8f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();

            yield break;
        }

        if(value == 2){
            anim[1].Play("PistolWater");

            yield return new WaitForSeconds(0.4f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(0.4f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(0.4f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(0.4f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(0.4f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();

            yield break;
        }

        if(value == 3){
            anim[2].Play("springjump");

            yield return new WaitForSeconds(1.1f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(1.1f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();

            yield break;
        }

        if(value == 4){
            anim[3].Play("jumpBiker");

            yield return new WaitForSeconds(1.1f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(1.8f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
            yield return new WaitForSeconds(2.9f);
            FindObjectOfType<ScoreAndClicks>().PlusClicks();

            yield break;
        }
    }
}

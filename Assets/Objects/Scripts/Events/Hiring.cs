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
    public List<GameObject>animList = new List<GameObject>();
    public Animator[] anim;
    [SerializeField] public GameObject ar;
    [SerializeField] public GameObject[] hiredOn;
    [SerializeField] public GameObject[] hiredOff;
    public Image[] items;
    [SerializeField] public int[] price;
    private int selectedObject;
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
            selectedObject = 1;
            items[0].color = new Color (255, 255, 255);
            PlayerPrefs.SetInt("BugBought", selectedObject);
            ar = animList[selectedObject];
            hiredOn[0].SetActive(false);
            hiredOff[0].SetActive(true);
            Unhire(2);
            Unhire(3);
        }
        if(value == 2 && GameManaging.o2 >= price[1] && gunBought == false){
            GameManaging.o2 -= price[1];
            gunBought = true;
            selectedObject = 2;
            PlayerPrefs.SetInt("GunBought", selectedObject);
            items[1].color = new Color (255, 255, 255);
            ar = animList[selectedObject];
            Unhire(1);
            Unhire(3);
            hiredOn[1].SetActive(false);
            hiredOff[1].SetActive(true);
        }
        if(value == 3 && GameManaging.o2 >= price[2] && springBought == false){
            GameManaging.o2 -= price[2];
            springBought = true;
            PlayerPrefs.SetInt("SpringBought", selectedObject);
            items[2].color = new Color (255, 255, 255);
            ar = animList[selectedObject];
            selectedObject = 3;
            Unhire(1);
            Unhire(2);
            hiredOn[2].SetActive(false);
            hiredOff[2].SetActive(true);
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
        }

        if(value == 2 && gunBought == true){
            hiredOn[1].SetActive(true);
            hiredOff[1].SetActive(false);
            items[1].color = new Color (0, 0, 0);
            StopCoroutine(Scoring(2));
            gunBought = false;
        }

        if(value == 3 && springBought == true){
            hiredOn[2].SetActive(true);
            hiredOff[2].SetActive(false);
            items[2].color = new Color (0, 0, 0);
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
        if(PlayerPrefs.HasKey("BugBought"))
        {
            bugBought = PlayerPrefs.GetInt("BugBought") == 1;
            PlayerPrefs.SetInt("BugBought", selectedObject);
            ar = animList[selectedObject];
        }
        else{
            PlayerPrefs.SetInt("BugBought", 1);
            PlayerPrefs.SetInt("BugBought", bugBought ? 1 : 0);
        }

        if(PlayerPrefs.HasKey("GunBought"))
        {
            gunBought = PlayerPrefs.GetInt("GunBought") == 1;
            PlayerPrefs.SetInt("GunBought", selectedObject);
            ar = animList[selectedObject];
        }
        else{
            PlayerPrefs.SetInt("GunBought", 1);
            PlayerPrefs.SetInt("GunBought", gunBought ? 1 : 0);
        }

        if(PlayerPrefs.HasKey("SpringBought"))
        {
            springBought = PlayerPrefs.GetInt("SpringBought") == 1;
            PlayerPrefs.SetInt("SpringBought", selectedObject);
            ar = animList[selectedObject];
        }
        else{
            PlayerPrefs.SetInt("SpringBought", 1);
            PlayerPrefs.SetInt("SpringBought", springBought ? 1 : 0);
        }       
    }
}

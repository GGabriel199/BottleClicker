using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ChangeSkin : MonoBehaviour
{
    public GameObject sr = GameManaging.sr;
    public int selectedSprite;
    public List<GameObject> playerPrefabs = new List<GameObject>();


    public void PlayGame(){
        SceneManager.LoadScene(0);
    }

    public void WaterBottle(){
        selectedSprite = 0;
        PlayerPrefs.SetInt("SelectedSprite", selectedSprite);
        FindObjectOfType<SoundManager>().Play("TapGlass");
        sr = playerPrefabs[selectedSprite];
        sr.SetActive(false);
        Invoke("PlayGame", 3);
    }

    public void JuiceJar(){
        selectedSprite = 1;
        PlayerPrefs.SetInt("SelectedSprite", selectedSprite);
        FindObjectOfType<SoundManager>().Play("TapGlass");
        sr = playerPrefabs[selectedSprite];
        sr.SetActive(false);
        Invoke("PlayGame", 3);
    }

    public void Coffee(){
        selectedSprite = 2;
        PlayerPrefs.SetInt("SelectedSprite", selectedSprite);
        FindObjectOfType<SoundManager>().Play("ThermicBottle");
        sr = playerPrefabs[selectedSprite];
        sr.SetActive(false);
        Invoke("PlayGame", 3);
    }

    public void SodaBottle(){
        selectedSprite = 3;
        PlayerPrefs.SetInt("SelectedSprite", selectedSprite);
        FindObjectOfType<SoundManager>().Play("OpenCan1");
        sr = playerPrefabs[selectedSprite];
        sr.SetActive(false);
        Invoke("PlayGame", 3);
    }

    public void Flask(){
        selectedSprite = 4;
        PlayerPrefs.SetInt("SelectedSprite", selectedSprite);
        FindObjectOfType<SoundManager>().Play("ThermicBottle");
        sr = playerPrefabs[selectedSprite];
        sr.SetActive(false);
        Invoke("PlayGame", 3);
    }

    public void Christmass(){
        selectedSprite = 5;
        PlayerPrefs.SetInt("SelectedSprite", selectedSprite);
        FindObjectOfType<SoundManager>().Play("OpenCan1");
        sr = playerPrefabs[selectedSprite];
        sr.SetActive(false);
        Invoke("PlayGame", 3);
    }
}

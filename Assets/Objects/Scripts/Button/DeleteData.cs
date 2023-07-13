using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteData : MonoBehaviour
{
    public static GameObject sr;
    private int selectedSprite;
    public GameObject[] selectedPrefab;  
    public void Delete(){
        PlayerPrefs.DeleteKey("prefMoney");
        PlayerPrefs.DeleteKey("o2");
        PlayerPrefs.DeleteKey("costSoda");
        PlayerPrefs.DeleteKey("costWine");
        PlayerPrefs.DeleteKey("costChoppMachine");
        PlayerPrefs.DeleteKey("costMultiplier");
        PlayerPrefs.DeleteKey("PlayerLevel");
        PlayerPrefs.DeleteKey("maxValue");
        PlayerPrefs.DeleteKey("BugBought");
        PlayerPrefs.DeleteKey("GunBought");
        PlayerPrefs.DeleteKey("SpringBought");
        PlayerPrefs.DeleteKey("muted");
        PlayerPrefs.DeleteKey("LocationX");
        PlayerPrefs.DeleteKey("LocationY");
        PlayerPrefs.DeleteKey("MusicOff");
        PlayerPrefs.DeleteKey("NextSong");
        PlayerPrefs.DeleteKey("TimesClickedMultiplier");
        PlayerPrefs.DeleteKey("BikerBought");
        PlayerPrefs.DeleteKey("PanelClosed");

        selectedSprite = 0;
            sr = Instantiate(selectedPrefab[selectedSprite]) as GameObject;
            sr.transform.SetParent(transform);
            sr.SetActive(true);
            PlayerPrefs.SetInt("SelectedSprite", selectedSprite);

        SceneManager.LoadScene(0);
    }
}

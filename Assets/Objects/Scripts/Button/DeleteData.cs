using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteData : MonoBehaviour
{
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
        
        SceneManager.LoadScene(0);
    }
}

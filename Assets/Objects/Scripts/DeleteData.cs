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
        PlayerPrefs.DeleteKey("PlayerLevel");
        PlayerPrefs.DeleteKey("maxValue");
        SceneManager.LoadScene(0);
    }
}

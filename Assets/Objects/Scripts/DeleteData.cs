using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteData : MonoBehaviour
{
    public void Delete(){
        PlayerPrefs.DeleteKey("prefMoney");
        PlayerPrefs.DeleteKey("o2");
        PlayerPrefs.DeleteKey("cost");
        PlayerPrefs.DeleteKey("PlayerLevel");
        SceneManager.LoadScene(0);
    }
}

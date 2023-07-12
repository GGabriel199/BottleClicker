using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPanel : MonoBehaviour
{
    public GameObject panel;

    void Start(){
        if(PlayerPrefs.HasKey("PanelClosed") == false)
        {
            panel.SetActive(true);
            AudioListener.pause = true;
        }
        else{
            panel.SetActive(false);
            AudioListener.pause = false;
        }
    }

    public void OnButtonPressed(){
        panel.SetActive(false);
        PlayerPrefs.SetInt("PanelClosed", 1);
        SceneManager.LoadScene(0);
    }
}

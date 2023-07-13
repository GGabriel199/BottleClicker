using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PolicyMenu : MonoBehaviour
{
    private string policyKey = "policy";
    public GameObject panel;
    private string policyLink = "https://sites.google.com/view/ggamingstudio/policy-terms-bottle-clicker";
    public TextMeshProUGUI link;

    void Start(){
        if(PlayerPrefs.HasKey(policyKey)){
            OnAccept();
        }
        else{
            panel.SetActive(true);
            link.text = "Privacy & Terms: " + policyLink;
        }
    }

    public void OnAccept(){
        panel.SetActive(false);
        PlayerPrefs.SetInt(policyKey, 1);
    }

    public void OnDecline(){
        Application.Quit();
    }

    public void OpenUrl(){
        Application.OpenURL(policyKey);
    }
}

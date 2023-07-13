using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenUrl : MonoBehaviour
{
    public TextMeshProUGUI link;
    private string policy = "https://sites.google.com/view/ggamingstudio/policy-terms-bottle-clicker";

    void Start(){
        link.text = "Privacy & Terms: " + policy;
    }
    public void URL(){
        Application.OpenURL(policy);
    }
}

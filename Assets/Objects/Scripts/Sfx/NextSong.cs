using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSong : MonoBehaviour
{
    private int isPressed;

    void Start(){
        isPressed = PlayerPrefs.GetInt("NextSong");
    }
    public void OnButtonPress(){
        isPressed ++;
        if(isPressed == 1){
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme");
            FindObjectOfType<SoundManager>().Play("Main Theme 2");
            isPressed = -1;
            PlayerPrefs.SetInt("NextSong", isPressed);
        }
        else{
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 2");
            FindObjectOfType<SoundManager>().Play("Main Theme");
            PlayerPrefs.SetInt("NextSong", isPressed);
        }
    }
}

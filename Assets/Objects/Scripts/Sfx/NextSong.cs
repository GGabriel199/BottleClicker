using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSong : MonoBehaviour
{
    private int selectedMusic;

    public void NextMusic(){
        selectedMusic = selectedMusic + 1;
        if(selectedMusic == 0){
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 2");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 3");
            FindObjectOfType<SoundManager>().Play("Main Theme");
        }
        if(selectedMusic == 1){
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 3");
            FindObjectOfType<SoundManager>().Play("Main Theme 2");
        }
        if(selectedMusic == 2){
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme ");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 2");
            FindObjectOfType<SoundManager>().Play("Main Theme 3");
        }
        if(selectedMusic > 2){
            selectedMusic = -1;
        }
    }
    public void PreviousMusic(){
        selectedMusic = selectedMusic - 1;
        if(selectedMusic < 0){
            selectedMusic = 2;
        }
        if(selectedMusic == 0){
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 2");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 3");
            FindObjectOfType<SoundManager>().Play("Main Theme");
        }
        if(selectedMusic == 1){
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 3");
            FindObjectOfType<SoundManager>().Play("Main Theme 2");
        }
        if(selectedMusic == 2){
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 2");
            FindObjectOfType<SoundManager>().Play("Main Theme 3");
        }
        
    }
}

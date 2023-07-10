using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSong : MonoBehaviour
{
    private int selectedMusic;


    public void NextMusic(){
        selectedMusic = selectedMusic + 1;
        if(selectedMusic == 0){
            FindObjectOfType<MusicOnOff>().Music(1);
        }
        if(selectedMusic == 1){
            FindObjectOfType<MusicOnOff>().Music(2);
        }
        if(selectedMusic == 2){
            FindObjectOfType<MusicOnOff>().Music(3);
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
            FindObjectOfType<MusicOnOff>().Music(1);
        }
        if(selectedMusic == 1){
            FindObjectOfType<MusicOnOff>().Music(2);
        }
        if(selectedMusic == 2){
            FindObjectOfType<MusicOnOff>().Music(3);
        }
        
    }
}

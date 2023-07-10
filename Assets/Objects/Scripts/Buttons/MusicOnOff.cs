using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour
{
    [SerializeField] public GameObject musicOn;
    [SerializeField] public GameObject musicOff;
    private bool muted = false;
    [SerializeField] public AudioSource track1;
    [SerializeField] public AudioSource track2;
    [SerializeField] public AudioSource track3;
    public Button[] button;
    [SerializeField] public static int randomNumber;
    private int trackHistory;

    void Start(){
        randomNumber = Random.Range(1,4);
        muted = PlayerPrefs.GetInt("MusicOff") == 1;
        if (muted == false)
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
            NextTrack();
            button[0].interactable = true;
            button[1].interactable = true;
        }
        else
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
            track1.Stop();
            track2.Stop();
            track3.Stop();
            button[0].interactable = false;
            button[1].interactable = false;
        }
        if (PlayerPrefs.HasKey("MusicOff"))
        {
            Load();
        }
        else
        {
            PlayerPrefs.SetInt("MusicOff", 1);
            Save();
        }

    }

    void Update(){
        if(muted == false){
            NextTrack();
        }
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
            button[0].interactable = true;
            button[1].interactable = true;
        }
        else
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
            button[0].interactable = false;
            button[1].interactable = false;
        }
    }

    private void NextTrack(){
        if(track1.isPlaying == false && track2.isPlaying == false && track3.isPlaying == false){
            randomNumber = Random.Range(1,4);
            trackHistory = Random.Range(1,4);
            if(randomNumber == 1 && trackHistory != 1){
                track1.Play();
                trackHistory = 1;
            }
            else if(randomNumber == 2 && trackHistory != 2){
                track2.Play();
                trackHistory = 2;
            }
            else if(randomNumber == 3 && trackHistory != 3){
                track3.Play();
                trackHistory = 3;
            }
        }
    }


    public void Music(int value){
        randomNumber = value;
        if(value == 1 && trackHistory != 1){
            track1.Play();
            track2.Stop();
            track3.Stop();
            trackHistory = 1;
        }
        else if(value == 2 && trackHistory != 2){
            track2.Play();
            track1.Stop();
            track3.Stop();
            trackHistory = 2;
        }
        else if(value == 3 && trackHistory != 3){
            track3.Play();
            track1.Stop();
            track2.Stop();
            trackHistory = 3;
        }
    }
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            track1.Stop();
            track2.Stop();
            track3.Stop();
        }
        else
        {
            muted = false;
            NextTrack();
        }
        UpdateButtonIcon();
        Save();
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("MusicOff") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("MusicOff", muted ? 1 : 0);
    }
}

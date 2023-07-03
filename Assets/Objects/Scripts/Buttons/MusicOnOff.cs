using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour
{
    [SerializeField] public GameObject musicOn;
    [SerializeField] public GameObject musicOff;
    private bool muted = false;
    public Button[] button;
    private int randomNumber;
    void Start(){
        randomNumber = Random.Range(1,4);
        muted = PlayerPrefs.GetInt("MusicOff") == 1;
        if (muted == false)
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
            Music();
            button[0].interactable = true;
            button[1].interactable = true;
        }
        else
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 2");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 3");
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

    private void Music(){
        if(randomNumber == 1){
            FindObjectOfType<SoundManager>().Play("Main Theme");
        }
        else if(randomNumber == 2){
            FindObjectOfType<SoundManager>().Play("Main Theme 2");
        }
        else if(randomNumber == 3){
            FindObjectOfType<SoundManager>().Play("Main Theme 3");
        }
    }
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 2");
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme 3");
        }
        else
        {
            muted = false;
            Music();
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

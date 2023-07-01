using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnOff : MonoBehaviour
{
    [SerializeField] public GameObject musicOn;
    [SerializeField] public GameObject musicOff;
    private bool muted = false;
    void Start(){
        muted = PlayerPrefs.GetInt("MusicOff") == 1;
        if (muted == false)
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
            FindObjectOfType<SoundManager>().Play("Main Theme");
        }
        else
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme");
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
        }
        else
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            FindObjectOfType<SoundManager>().StopPlaying("Main Theme");
        }
        else
        {
            muted = false;
            FindObjectOfType<SoundManager>().Play("Main Theme");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxOnOff : MonoBehaviour
{
    [SerializeField] public GameObject sfxOff;
    [SerializeField] public GameObject sfxOn;
    private bool muted = false;

    void Awake(){
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    void Start(){
        if (muted == false)
        {
            sfxOn.SetActive(true);
            sfxOff.SetActive(false);
        }
        else
        {
            sfxOn.SetActive(false);
            sfxOff.SetActive(true);
        }
        if (PlayerPrefs.HasKey("muted"))
        {
            Load();
        }
        else
        {
            PlayerPrefs.SetInt("muted", 1);
            Save();
        }

        AudioListener.pause = muted;
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            sfxOn.SetActive(true);
            sfxOff.SetActive(false);
        }
        else
        {
            sfxOn.SetActive(false);
            sfxOff.SetActive(true);
        }
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        UpdateButtonIcon();
        Save();
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}

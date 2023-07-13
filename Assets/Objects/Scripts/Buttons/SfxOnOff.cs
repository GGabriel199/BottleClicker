using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxOnOff : MonoBehaviour
{
    [SerializeField] public GameObject sfxOff;
    [SerializeField] public GameObject sfxOn;
    private float muted = 0;

    void Awake(){
        muted = PlayerPrefs.GetFloat("muted", 1);
    }

    void Start(){
        if (muted == 0)
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
            PlayerPrefs.SetFloat("muted", 1);
            Save();
        }

        AudioListener.volume = muted;
    }

    private void UpdateButtonIcon()
    {
        if (muted == 0)
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
        if (muted == 0)
        {
            muted = 1;
            AudioListener.volume = 1;
        }
        else
        {
            muted = 0;
            AudioListener.volume = 0;
        }
        UpdateButtonIcon();
        Save();
    }
    private void Load()
    {
        muted = PlayerPrefs.GetFloat("muted", 0);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("muted", muted);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxOnOff : MonoBehaviour
{
    public GameObject sfxOn;
    public GameObject sfxOff;
    public void SfxOn()
    {
        FindObjectOfType<SoundManager>().Play("Click2");
        FindObjectOfType<SoundManager>().Play("BottleClick");
        FindObjectOfType<SoundManager>().Play("ClickOff");
        FindObjectOfType<SoundManager>().Play("LevelUp");
        FindObjectOfType<SoundManager>().Play("Click3");
        FindObjectOfType<SoundManager>().Play("Selected");
        sfxOn.SetActive(false);
        sfxOff.SetActive(true);
    }

    public void SfxOff()
    {
        FindObjectOfType<SoundManager>().StopPlaying("Click2");
        FindObjectOfType<SoundManager>().StopPlaying("BottleClick");
        FindObjectOfType<SoundManager>().StopPlaying("ClickOff");
        FindObjectOfType<SoundManager>().StopPlaying("LevelUp");
        FindObjectOfType<SoundManager>().StopPlaying("Click3");
        FindObjectOfType<SoundManager>().StopPlaying("Selected");
        sfxOff.SetActive(false);
        sfxOn.SetActive(true);
    }
}

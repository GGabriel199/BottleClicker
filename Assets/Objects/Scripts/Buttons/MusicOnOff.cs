using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnOff : MonoBehaviour
{
    public GameObject musicOn;
    public GameObject musicOff;
    public void MusicOn()
    {
        FindObjectOfType<SoundManager>().Play("Main Theme");
        musicOn.SetActive(false);
        musicOff.SetActive(true);
    }

    public void MusicOff()
    {
        FindObjectOfType<SoundManager>().StopPlaying("Main Theme");
        musicOff.SetActive(false);
        musicOn.SetActive(true);
    }
}

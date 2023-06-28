using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxOnOff : MonoBehaviour
{
    public GameObject sfxOn;
    public GameObject sfxOff;

    public void Sfx(bool muted)
    {
        if(muted == false){
            AudioListener.volume = 1;
            sfxOff.SetActive(true);
            sfxOn.SetActive(false);
        }
        else{
            AudioListener.volume = 0;
            sfxOff.SetActive(false);
            sfxOn.SetActive(true);
        }
        
    }
}

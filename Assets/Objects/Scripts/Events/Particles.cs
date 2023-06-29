using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Particles : MonoBehaviour
{
    public GameObject[] particles;

    public void SoundAndEffects(){
        if(GameManaging.o2 >= 200000){
            particles[0].SetActive(true);
            FindObjectOfType<SoundManager>().Play("Bubbles");
        }

        if(GameManaging.o2 >= 600000){
            particles[1].SetActive(true);
            particles[0].SetActive(false);
            
            FindObjectOfType<SoundManager>().StopPlaying("Bubbles");
            FindObjectOfType<SoundManager>().Play("Rain");
        }
    }
}

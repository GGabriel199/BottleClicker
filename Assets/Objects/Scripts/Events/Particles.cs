using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Particles : MonoBehaviour
{
    public GameObject[] particles;

    public void Bubbles(){
        if(GameManaging.o2 >= 200000 && GameManaging.o2 <= 205000){
            particles[0].SetActive(true);
            particles[1].SetActive(false);
            FindObjectOfType<SoundManager>().Play("Bubbles");
            FindObjectOfType<SoundManager>().StopPlaying("Rain");
            FindObjectOfType<SoundManager>().StopPlaying("Flames");
        }
    }

    public void Rain(){
        if(GameManaging.o2 >= 600000 && GameManaging.o2 <= 620000){
            FindObjectOfType<SoundManager>().Play("Rain");
            FindObjectOfType<SoundManager>().StopPlaying("Bubbles");
            particles[1].SetActive(true);
            particles[0].SetActive(false);
        }
    }

    public void Flames(){
        if(GameManaging.o2 >= 1100000 && GameManaging.o2 <= 1150000){
            particles[2].SetActive(true);
            FindObjectOfType<SoundManager>().Play("Flames");
            FindObjectOfType<SoundManager>().StopPlaying("Rain");
            particles[1].SetActive(false);
        }
    }

    public void StopParticles(){
        particles[0].SetActive(false);
        particles[1].SetActive(false);
        particles[2].SetActive(false);
        FindObjectOfType<SoundManager>().StopPlaying("Bubbles");
        FindObjectOfType<SoundManager>().StopPlaying("Rain");
        FindObjectOfType<SoundManager>().StopPlaying("Flames");
    }
}

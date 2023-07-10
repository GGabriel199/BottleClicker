using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Particles : MonoBehaviour
{
    public GameObject[] particles;

    public void Bubbles(){
        if(GameManaging.o2 >= 200000 && GameManaging.o2 <= 600000){
            particles[0].SetActive(true);
            FindObjectOfType<SoundManager>().Play("Bubbles");
        }
        else{
            particles[0].SetActive(false);
            FindObjectOfType<SoundManager>().StopPlaying("Bubbles");
        }
    }

    public void Rain(){
        if(GameManaging.o2 >= 600000 && GameManaging.o2 <= 1100000){
            FindObjectOfType<SoundManager>().Play("Rain");
            particles[1].SetActive(true);
        }
        else{
            FindObjectOfType<SoundManager>().StopPlaying("Rain");
            particles[1].SetActive(false);
        }
    }

    public void Flames(){
        if(GameManaging.o2 >= 1100000){
            particles[2].SetActive(true);
            FindObjectOfType<SoundManager>().Play("Flames");
        }
        else{
            particles[2].SetActive(false);
            FindObjectOfType<SoundManager>().StopPlaying("Flames");
        }
    }
}

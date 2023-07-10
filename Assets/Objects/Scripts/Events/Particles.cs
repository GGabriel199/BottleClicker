using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Particles : MonoBehaviour
{
    public GameObject[] particles;

    void Start(){
        if(GameManaging.o2 >= 200000 && GameManaging.o2 <= 600000){
            particles[0].SetActive(true);
            FindObjectOfType<SoundManager>().Play("Bubbles");
        }

        if(GameManaging.o2 >= 600000 && GameManaging.o2 <= 1100000){
            particles[1].SetActive(true);
            
            FindObjectOfType<SoundManager>().Play("Rain");
        }
        if(GameManaging.o2 >= 1100000){
            particles[2].SetActive(true);

            FindObjectOfType<SoundManager>().Play("Flames");
        }
    }
}

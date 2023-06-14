using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject particles;
    void Update()
    {
        if(GameManaging.o2 >= 500000){
            particles.SetActive(true);
        }
        else{
            particles.SetActive(false);
        }
    }
}

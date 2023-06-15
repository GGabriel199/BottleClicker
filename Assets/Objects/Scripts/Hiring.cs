using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hiring : MonoBehaviour
{
    public float[] clickEvent;
    private static float currentTime = 10f;
    private float timerLimit;
    private bool isBought;
    public Animator[] anim;
    public Button[] button;
    public int[] price;
    public TextMeshProUGUI priceText;

    void Update(){
        priceText.text = "Buy$:" + price[0].ToString();
        if (currentTime < timerLimit)
        {
            currentTime = timerLimit;
            if (timerLimit == 0)
            {
                AnimationInTime();
                currentTime += 10f;
            }
        }
        if(isBought == true){
            currentTime = currentTime -= Time.deltaTime;
        }
        Debug.Log(currentTime);
    }

    public void HiringShop(int value){
        if(value == 1 && GameManaging.o2 >= price[0]){
            AnimationInTime();
            isBought = true;
            GameManaging.o2 -= price[0];
        }
    }


    public void AnimationInTime(){
        anim[0].Play("JumpAndClick");
        StartCoroutine(Scoring());
    }

    IEnumerator Scoring(){
        yield return new WaitForSeconds(clickEvent[0]);
        GameManaging.o2 += 1;
    
        yield break;
    }

}

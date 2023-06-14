using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hiring : MonoBehaviour
{
    private float[] clickEvent;
    public Animator[] anim;
    private int[] price;
    private int[] quantity;
    private int maxQuantity;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI priceText;

    void Update(){
        priceText.text = "Buy$:" + price.ToString();
        quantityText.text = "Qnt: " + quantity.ToString();
    }

    public void HiringShop(int value){
        if(value == 1 && GameManaging.o2 >= price[0]){
            
        }
    }

    public void AnimationInTime(){
        for (int i = 0; i>anim.Length; i++){
            anim[i].Play("Press");
        }
        
    }

}

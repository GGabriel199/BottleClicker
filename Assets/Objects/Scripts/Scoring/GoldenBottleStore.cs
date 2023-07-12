using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldenBottleStore : MonoBehaviour
{
    private int cost1 = 1;
    private int cost2 = 5;
    private int cost3 = 20;
    [SerializeField] public TextMeshProUGUI[] costText;

    void Update(){
        costText[0].text = "x" + cost1.ToString();
        costText[1].text = "x" + cost2.ToString();
        costText[2].text = "x" + cost3.ToString();
    }
    public void Store(int value){
        if(value == 1 && GameManaging.goldenO2 >= cost1){
            GameManaging.o2 += 25000;
            GameManaging.goldenO2 -= cost1;
            PlayerPrefs.SetInt("GoldenBottle", GameManaging.goldenO2);
        }
        if(value == 2 && GameManaging.goldenO2 >= cost2){
            GameManaging.o2 += 150000;
            GameManaging.goldenO2 -= cost2;
            PlayerPrefs.SetInt("GoldenBottle", GameManaging.goldenO2);
        }
        if(value == 3 && GameManaging.goldenO2 >= cost3){
            GameManaging.o2 += 1000000;
            GameManaging.goldenO2 -= cost3;
            PlayerPrefs.SetInt("GoldenBottle", GameManaging.goldenO2);
        }
    }
}

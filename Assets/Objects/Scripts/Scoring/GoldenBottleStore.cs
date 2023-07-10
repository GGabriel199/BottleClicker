using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldenBottleStore : MonoBehaviour
{
    private int[] cost;
    public TextMeshProUGUI[] costText;

    void Update(){
        costText[0].text = "x" + cost[0].ToString();
        costText[1].text = "x" + cost[1].ToString();
        costText[2].text = "x" + cost[2].ToString();
    }
    public void Store(int value){
        if(value == 1 && GameManaging.goldenO2 >= cost[0]){
            GameManaging.o2 += 25000;
            GameManaging.goldenO2 -= cost[0];
        }
        if(value == 2 && GameManaging.goldenO2 >= cost[1]){
            GameManaging.o2 += 150000;
            GameManaging.goldenO2 -= cost[1];
        }
        if(value == 3 && GameManaging.goldenO2 >= cost[2]){
            GameManaging.o2 += 1000000;
            GameManaging.goldenO2 -= cost[2];
        }
    }
}

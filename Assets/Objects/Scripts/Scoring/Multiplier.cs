using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiplier : MonoBehaviour
{
    private TextMeshProUGUI multiplier;

    void Start()
    {
        multiplier = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        multiplier.text = "x" + GameManaging.multiplier.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAndClicks : MonoBehaviour
{
    private int clicks;
    private int maxValue = 999999999;
    private int level;
    private string label;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI clicksText;
    public TextMeshProUGUI labelTxt;

    public GameObject bottle;

    void Start()
    {
        clicks = PlayerPrefs.GetInt("prefMoney");
        level = 1;
    }

    // Update is called once per frame
    public void PlusClicks()
    {
        clicks++;
        FindObjectOfType<SoundManager>().Play("BottleClick");
        PlayerPrefs.SetInt("prefMoney", clicks);
        if (clicks >= maxValue)
        {
            clicks = 0;
            level++;
        }
    }

    private void Update()
    {
        clicksText.text = clicks.ToString();
        levelText.text = level.ToString();
        labelTxt.text = label;
    }
}
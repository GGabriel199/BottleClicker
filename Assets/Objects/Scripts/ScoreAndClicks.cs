using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAndClicks : MonoBehaviour
{
    private int clicks;
    private int maxValue = 1000000000;
    private string label;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI clicksText;
    public TextMeshProUGUI labelTxt;
    public Animator anim;

    public GameObject bottle;

    void Start()
    {
        clicks = PlayerPrefs.GetInt("prefMoney");
    }

    private void Update()
    {
        clicksText.text = clicks.ToString();
        labelTxt.text = label;
    }

    public void PlusClicks()
    {
        clicks++;
        FindObjectOfType<SoundManager>().Play("BottleClick");
        anim.Play("Bottle");
        PlayerPrefs.SetInt("prefMoney", clicks);
        if (clicks >= maxValue)
        {
            clicks = 0;
            FindObjectOfType<PlayerLevel>().LevelUp();
        }
    }
}
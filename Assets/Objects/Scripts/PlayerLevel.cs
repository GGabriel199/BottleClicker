using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI txtLevel;
    public Animator popUp;
    public Sprite[] bottles;
    private void Start()
    {
        level = 1;
        level = PlayerPrefs.GetInt("PlayerLevel");
    }

    private void Update()
    {
        txtLevel.text = level.ToString();
    }

    public void LevelUp()
    {
        popUp.Play("LevelUp");
        level++;
        PlayerPrefs.SetInt("PlayerLevel", level);
    }
}

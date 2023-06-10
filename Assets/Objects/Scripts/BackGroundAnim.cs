using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundAnim : MonoBehaviour
{
    private int _level;
    public Animator animName;
    public Button[] buttons;

    private void Start()
    {
        _level = PlayerPrefs.GetInt("PlayerLevel");
        if (_level == 2)
        {
            buttons[0].interactable = true;
        }
    }

    public void Blue()
    {
        animName.Play("Scene1");
        FindObjectOfType<SoundManager>().Play("Click");
    }

    public void Tiles()
    {
        animName.Play("Scene2");
        FindObjectOfType<SoundManager>().Play("Click");
    }

    public void Sky()
    {
        animName.Play("Scene3");
        FindObjectOfType<SoundManager>().Play("Click");
    }
}

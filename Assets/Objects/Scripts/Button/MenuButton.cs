using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject panel;

    public void OpenMenu()
    {
        FindObjectOfType<SoundManager>().Play("Click3");
        panel.SetActive(true);
    }
}

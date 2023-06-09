using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject panel;

    public void OpenMenu()
    {
        panel.SetActive(true);
    }
}

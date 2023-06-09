using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    public void ClosePanel()
    {
        panel.SetActive(false);
    }

}

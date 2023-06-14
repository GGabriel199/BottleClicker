using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public GameObject label;

    public void OnClick(){
        label.SetActive(false);
    }
}

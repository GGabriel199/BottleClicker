using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public Animator openPanel;

    public void OpeningPanel(){
        openPanel.Play("DeleteDialogOut");
    }

    public void ClosePanel(){
        openPanel.Play("DeleteDialogIn");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] bottles;
    public AnimatorOverrideController bottle;
    public AnimatorOverrideController juice;
    public AnimatorOverrideController coffee;

    void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void StandardSkin(){
        GetComponent<Animator>().runtimeAnimatorController = bottle as RuntimeAnimatorController;
        spriteRenderer.sprite = bottles[0];
        FindObjectOfType<SoundManager>().Play("Selected");
    }

    public void JuiceSkin(){
        GetComponent<Animator>().runtimeAnimatorController = juice as RuntimeAnimatorController;
        spriteRenderer.sprite = bottles[1];
        FindObjectOfType<SoundManager>().Play("Selected");
    }

    public void Coffee(){
        GetComponent<Animator>().runtimeAnimatorController = coffee as RuntimeAnimatorController;
        spriteRenderer.sprite = bottles[2];
        FindObjectOfType<SoundManager>().Play("Selected");
    }
}

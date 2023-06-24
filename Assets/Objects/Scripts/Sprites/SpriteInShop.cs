using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpriteInShop : MonoBehaviour
{
    public SpritesInfo spriteInfo;
    public TextMeshProUGUI text;
    public Image skinImage;
    public Animator anim;
    [SerializeField] private bool isFreeSkin = true;
    [SerializeField] public bool isSkinUnlocked = true;

    void Awake(){
        skinImage.sprite = spriteInfo.skinSprite;
        isSkinUnlocked = true;

        if(isFreeSkin)
        {
            if (PlayerLevelManager.Instance.TrySelectItem(0))
            {
                PlayerPrefs.SetInt(spriteInfo.spriteId.ToString(), 1);
            }
        }

        IsSkinUnlocked();
    }

    private void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(spriteInfo.spriteId.ToString()) == 1)
        {
            isSkinUnlocked = true;
            text.text = "Select";
        }
        else
        {
            text.text = "Select";
        }
    }

    public void OnButtonPress()
    {
        if (isSkinUnlocked)
        {
            //equip
            ChangeSkin.Instance.SelectSkin(this);
            FindObjectOfType<SoundManager>().Play("OpenCan1");
        }
        else
        {
            //buy
            if (PlayerMoney.Instance.TryRemoveMoney(spriteInfo.cost))
            {
                FindObjectOfType<SoundManager>().Play("Click");
                PlayerPrefs.SetInt(spriteInfo.spriteId.ToString(), 1);
                IsSkinUnlocked();
            }
        }
    }
}

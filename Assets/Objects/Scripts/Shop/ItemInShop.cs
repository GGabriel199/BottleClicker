using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInShop : MonoBehaviour
{
    [SerializeField] private ShopInfo shopInfo;
    public ShopInfo _shopInfo { get { return shopInfo; } }

    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Image itemImage;

    private float clickPerSeconds;
    private int clicks;

    private void Awake()
    {        
        itemImage.sprite = shopInfo._itemSprite;
        IsSkinPurchased();
    }

    private void IsSkinPurchased()
    {
        if (PlayerPrefs.GetInt(shopInfo._itemID.ToString()) == 1)
        {
            buttonText.text = "Buy: " + shopInfo._cost;
            clickPerSeconds = shopInfo._timePerSecond;
            clicks += shopInfo._plusClicks;
        }
        else
        {
            buttonText.text = "Buy: " + shopInfo._cost;
        }
    }

    public void OnButtonPress()
    {
        if (PlayerMoney.Instance.TryRemoveMoney(shopInfo._cost))
        {
            FindObjectOfType<SoundManager>().Play("Click");
            PlayerPrefs.SetInt(_shopInfo._itemID.ToString(), 1);
            IsSkinPurchased();
            FindObjectOfType<ScoreAndClicks>().PlusClicks();
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{

    public static ChangeSkin Instance;
    public SpritesInfo[] allSkins;
    public SpriteRenderer playerSR;
    public static Sprite selectedBottle { get; private set; }
    private const string skinPref = "skinPref";
    private Button currentlyEquippedSkinButton;

    public AnimatorOverrideController waterBottle;
    public AnimatorOverrideController juice;
    public AnimatorOverrideController coffee;
    public AnimatorOverrideController soda;
    public AnimatorOverrideController flask;
    public AnimatorOverrideController christmassbt;

    [SerializeField] private Transform skinsInShopPanelsParent;
    [SerializeField] private List<SpriteInShop> skinsInShopPanels = new List<SpriteInShop>();

    void Awake(){
        Instance = this;

        foreach(Transform s in skinsInShopPanelsParent)
        {
            if (s.TryGetComponent(out SpriteInShop skinInShop))
            {
                skinsInShopPanels.Add(skinInShop);
            }
        }

        EquipPreviousSkin();

        SpriteInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind.spriteInfo.skinSprite == selectedBottle);
        currentlyEquippedSkinButton = skinEquippedPanel.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable= false;
    }

        private void EquipPreviousSkin()
    {
        string lastSkinUsed = PlayerPrefs.GetString("skinPref", SpritesInfo.SpriteIDs.waterBottle.ToString());
        SpriteInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind.spriteInfo.spriteId.ToString() == lastSkinUsed);
        SelectSkin(skinEquippedPanel);
    }

    public void SelectSkin(SpriteInShop spriteInfo){
        selectedBottle = spriteInfo.spriteInfo.skinSprite;
        PlayerPrefs.SetString("skinPref", spriteInfo.spriteInfo.spriteId.ToString());
        
        if(currentlyEquippedSkinButton != null)
            currentlyEquippedSkinButton.interactable = true;

        currentlyEquippedSkinButton = spriteInfo.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;
    }
}

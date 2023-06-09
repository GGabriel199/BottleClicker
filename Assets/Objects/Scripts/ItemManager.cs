using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    [SerializeField] private ShopInfo[] allItems;

    [SerializeField] private Transform itemInShopPanelParent;
    [SerializeField] private List<ItemInShop> itemInShopPanel = new List<ItemInShop>();

    void Awake()
    {
        Instance = this;

        foreach (Transform s in itemInShopPanelParent)
        {
           if (s.TryGetComponent(out ItemInShop itemInShop))
               itemInShopPanel.Add(itemInShop);
        }
    }
}

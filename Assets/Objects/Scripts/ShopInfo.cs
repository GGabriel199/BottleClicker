using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Item", menuName = "Create New Item")]
public class ShopInfo : ScriptableObject
{
    public enum ItemIDs
    { soda, wine, choppMachine }


    [SerializeField] private ItemIDs itemID;
    public ItemIDs _itemID { get { return itemID; } }

    [SerializeField] private Sprite itemSprite;
    public Sprite _itemSprite { get{ return itemSprite; } }

    [SerializeField] private int cost;
    public int _cost { get { return cost; } }


    [SerializeField] private float timePerSecond;
    public float _timePerSecond { get { return timePerSecond; } }


    [SerializeField] private int plusClicks;
    public int _plusClicks {get { return plusClicks; } }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Sprite", menuName = "Create New Sprite")]
public class SpritesInfo : ScriptableObject
{
    public enum SpriteIDs { waterBottle, juiceBottle, thermicBottle, sodaBottle, weirdBottle, christmasBottle }

    public SpriteIDs spriteId;

    public Sprite skinSprite;
    public int cost;
}

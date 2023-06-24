using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int level;
    public bool TrySelectItem(int itemToSelect){
        level = PlayerLevel.level;
        if(level >= itemToSelect){
            return true;
        }
        else{
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : MonoBehaviour
{
    public ItemData(string itemName, Rarity rarity)
    {
        ItemName = itemName;
        ItemRarity = rarity;
    }

    public enum Rarity
    {
        Common,
        Rare
    }

    public string ItemName;
    public Rarity ItemRarity;
}

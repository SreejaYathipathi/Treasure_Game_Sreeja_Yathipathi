using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public Rarity ItemRarity;
    public string ItemName;
    public Sprite icon;
    public virtual int Values {  get; }

    public ItemType itemtype;

    public enum ItemType
    {
        Potion,
        Weapon
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary
    }

    // Initialization method to set item properties
    public void Initialize(string itemName, Rarity rarity)
    {
        this.ItemName = itemName;
        this.ItemRarity = rarity;
    }

    public virtual void UseItem()
    {
        Debug.Log($"Using item: {this.ItemName}");
    }
}

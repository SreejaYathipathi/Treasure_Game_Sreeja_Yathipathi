using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemData itemData;
    //private InGameHUD GameHud;

    public Button RemoveButton;
    public void Removeitem()
    {
        if (itemData != null)
        {
            InventoryManager.Instance.Remove(this);
            Destroy(gameObject);
        }
    }

    public void AddItem(ItemData newItem)
    {

        if (newItem == null)
        {
            Debug.LogError("Tried to add a null item to the inventory.");
            return;
        }

        itemData = newItem;
    }

    public void ItemUsed()
    {
        switch (itemData.itemtype)
        {
            case ItemData.ItemType.Potion:
                // Now it correctly uses the healingAmount from Potions
                InGameHUD.Instance.IncreaseHealth(itemData.Values);
                break;
            case ItemData.ItemType.Weapon:
                // Now it correctly uses the damageValue from Weapons
                InGameHUD.Instance.IncreaseScore(itemData.Values);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private UIManager _uiManager;  // Reference to the UIManager
    public ItemData itemData;

    public Button RemoveButton;

    private void Awake()
    {
        // Ensure UIManager reference is set
        _uiManager = FindObjectOfType<UIManager>();
    }
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
                Debug.Log($"IncreaseScore : {itemData.Values}");
                InGameHUD.Instance.IncreaseScore(itemData.Values);
                Debug.Log($"DecreaseHealth : {itemData.Values}");
                Enemy.Instance.TakeDamage(itemData.Values);
                break;
        }
    }
}

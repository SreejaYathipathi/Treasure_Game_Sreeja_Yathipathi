using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private bool isItemNearby = false; // Tracks if the player is near the item
    private UIManager uiManager; // Reference to the UI Manager

    // Reference to the item's data
    private List<ItemData> itemData = new List<ItemData>();
    private GameObject itemPlayerFacing;


    private void Start()
    {
        // Find the UIManager and Inventory in the scene
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene. Please ensure there is a UIManager in the scene.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            var item = other.gameObject.GetComponent<ItemData>();
            if (!itemData.Contains(item))
            {
                itemData.Add(other.gameObject.GetComponent<ItemData>());
            }
            itemPlayerFacing = other.gameObject;
            isItemNearby = true;

            if (itemData.Any())
            {
                if (itemData[0] != null && uiManager != null)
                {
                    // Display item information when the player is nearby
                    string message = $"Press F to pick up: {itemData[0].ItemName}\n" +
                                     $"Rarity: {itemData[0].ItemRarity}";

                    // Check if the item is a weapon or potion to display specific attributes
                    if (itemData[0] is Weapons weapon)
                    {
                        message += $"\nDamage: {weapon.minDamageValue} - {weapon.maxDamageValue}";
                    }
                    else if (itemData[0] is Potions potion)
                    {
                        message += $"\nHealing: {potion.healingAmount}";
                    }

                    uiManager.ShowMessagePanel(message);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TChest"))
        {
            isItemNearby = false;
            if (uiManager != null)
            {
                uiManager.HideMessagePanel();
            }
        }
    }

    private void Update()
    {
        if (isItemNearby && Input.GetKeyDown(KeyCode.F))
        {
            PickUpItem();
        }
    }

    private void PickUpItem()
    {
        if (itemData.Any())
        {
            if (itemData[0] != null)
            {

                // Display pickup confirmation
                string message = $"Picked up: {itemData[0].ItemName}\n" +
                                 $"Rarity: {itemData[0].ItemRarity}";

                Debug.Log($"Adding item to inventory: {itemData[0]?.ItemName ?? "Null Item"}");

                // Check if the item is a weapon or potion to display specific attributes

                if (itemData[0] is Weapons weapon)
                {
                    message += $"\nDamage: {weapon.minDamageValue} - {weapon.maxDamageValue}";
                }
                else if (itemData[0] is Potions potion)
                {
                    message += $"\nHealing: {potion.healingAmount}";
                }

                // Show the message panel
                if (uiManager != null)
                {
                    uiManager.ShowMessagePanel(message);
                    StartCoroutine(HandleMessagePanel());

                }

                if (InventoryManager.Instance != null)
                {
                    InventoryManager.Instance.Add(itemData[0]);
                }

                else
                {
                    Debug.LogError("InventoryManager instance is null!");
                }

                // Log for debugging
                Debug.Log(message);

                // Destroy the item object in the scene after a short delay
                itemData[0].gameObject.SetActive(false); // Slight delay for feedback
            }
            itemData.Remove(itemData[0]);
        }
    }


    // Method to hide the message panel
    private void HideMessagePanel()
    {
        if (uiManager != null)
        {
            uiManager.HideMessagePanel();
        }
    }


    IEnumerator HandleMessagePanel()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Handled well");
        uiManager.HideMessagePanel();

    }

}

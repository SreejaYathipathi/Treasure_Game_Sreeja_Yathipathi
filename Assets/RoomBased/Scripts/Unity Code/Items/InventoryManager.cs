using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemData> Items = new List<ItemData>();
    [SerializeField] private GameObject _inventoryScreen;

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;

    public InventoryItem[] inventoryItems;

    private Weapons selectedWeapon;
    private Potions selectedPotion;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Check for Tab key press to toggle inventory visibility
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        bool isInventoryActive = _inventoryScreen.activeSelf;
        _inventoryScreen.SetActive(!isInventoryActive);
        ListItems();
    }

    public void Add(ItemData itemData)
    {

        Debug.Log("Added item");
        Items.Add(itemData);
    }

    public void Remove(InventoryItem inventoryItem)
    {

        Debug.Log("Used item");

        inventoryItem.ItemUsed();

        Debug.Log("Removed item");
        Items.Remove(inventoryItem.itemData);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var itemData in Items)
        {

            if (itemData == null)
            {
                Debug.LogWarning("Null item found in inventory list. Skipping.");
                continue;
            }


            GameObject obj = Instantiate(InventoryItem, ItemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            if (itemName == null) Debug.LogError("ItemName Text component not found in InventoryItem prefab.");
            if (itemIcon == null) Debug.LogError("ItemIcon Image component not found in InventoryItem prefab.");
            if (removeButton == null) Debug.LogError("RemoveButton not found in InventoryItem prefab.");

            itemName.text = itemData.ItemName;
            itemIcon.sprite = itemData.icon;

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(false);
            }
        }

        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
        if(EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        inventoryItems = ItemContent.GetComponentsInChildren<InventoryItem>();

        for(int i = 0;i < Items.Count;i++)
        {
            Debug.Log("Items list");
            inventoryItems[i].AddItem(Items[i]);
        }
    }

    private void SelectItem(ItemData itemData)
    {
        if (itemData is Weapons)
        {
            selectedWeapon = itemData as Weapons;
            Debug.Log("Weapon selected: " + selectedWeapon.ItemName);
        }
        else if (itemData is Potions)
        {
            selectedPotion = itemData as Potions;
            Debug.Log("Potion selected: " + selectedPotion.ItemName);
        }
    }

    // Public methods to get the selected items
    public Weapons GetSelectedWeapon()
    {
        return selectedWeapon;
    }

    public Potions GetSelectedPotion()
    {
        return selectedPotion;
    }
}

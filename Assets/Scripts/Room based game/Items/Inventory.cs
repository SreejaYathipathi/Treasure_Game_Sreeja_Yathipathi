//using UnityEngine;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GD12_1133_A2_SreejaYathipathi
//{
//    public class Inventory
//    {
//        public List<Things> things = new List<Things>(); // List to hold items

//        public void AddItem(Things item)
//        {
//            // Check if the item is already in the inventory
//            Consumable existingConsumable = null;

//            foreach (var i in things)
//            {
//                if (i is Consumable consumable && consumable.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase))
//                {
//                    existingConsumable = consumable;
//                    break; // Exit the loop once the item is found
//                }
//            }

//            if (existingConsumable != null)
//            {
//                // Increment the count of the existing item (if applicable)
//                if (existingConsumable is Consumable consumable)
//                {
//                    consumable.IncrementCount(); // Implement this in your Consumable class
//                    Debug.Log($"You already have {existingConsumable.Name}. You now have {consumable.Count} of them.");
//                }
//            }
//            else
//            {
//                things.Add(item);
//                Debug.Log($"{item.Name} has been added to your inventory.");
//            }

//            // Show inventory after adding an item
//            ShowInventory();
//        }

//        public bool RemoveItem(Things item)
//        {
//            if (things.Remove(item))
//            {
//                Debug.Log($"{item.Name} has been removed from the inventory.");
//                return true;
//            }
//            else
//            {
//                Debug.Log($"{item.Name} not found in the inventory.");
//            }
//            return false;
//        }

//        // Check if the player has a specific consumable or weapon
//        public bool HasItem(string itemName)
//        {
//            foreach (var item in things)
//            {
//                if (item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase))
//                {
//                    return true; // Item found
//                }
//            }
//            return false; // Item not found
//        }

//        // Check for consumable items in the inventory
//        public bool HasConsumable()
//        {
//            return things.OfType<Consumable>().Any();
//        }

//        // Check for weapon items in the inventory
//        public bool HasWeapon()
//        {
//            return things.OfType<Weapon>().Any();
//        }



//        public void ShowInventory()
//        {
//            Debug.Log("Current Inventory:");
//            if (things.Count == 0)
//            {
//                Debug.Log("Your inventory is empty.");
//                return;
//            }
//            foreach (var item in things)
//            {
//                Debug.Log($"- {item.Name}: {item.Description}");
//                if (item is Consumable consumable)
//                {
//                    Debug.Log($"  Count: {consumable.Count}"); // Assuming Count is a property of Consumable
//                }
//            }
//        }
        
//    }
//}

//using UnityEngine;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;

//namespace GD12_1133_A2_SreejaYathipathi
//{
//    public class TreasureRoom : Room
//    {
//        private List<Things> availableItems = new List<Things>
//        {
//            new LongSword(),
//            new Dagger(),
//            new Polearm(),
//            new SmallHealingPotion(),
//            new MediumHealingPotion(),
//            new LargeHealingPotion()
//        };

//        public TreasureRoom() : base("Treasure") { }

//        public override void OnEntered()
//        {
//            Debug.Log("You have entered the Treasure Room! Gleaming gold and precious gems surround you.");
//            Debug.Log("Do you want to search the Treasure Room?");
//            Debug.Log("Please enter yes or no");
//            string treasuresearchchoice = Console.ReadLine() ?? "".ToLower();
//            while (treasuresearchchoice != "yes" && treasuresearchchoice != "no")
//            {
//                Debug.Log("Please enter yes or no");
//                treasuresearchchoice = Console.ReadLine() ?? "".ToLower();
//            }
//            if (treasuresearchchoice == "yes")
//            {
//                OnSearched();
//            }
//            else if (treasuresearchchoice == "no")
//            {
//                Debug.Log("You chose not to search the room.");
//            }
//        }

//        public override void OnSearched()
//        {
//            Random random = new Random();
//            int itemCount = Random.Range(3, 5);

//            List<Things> selectedItems = new List<Things>();

//            // Shuffle the availableItems list
//            for (int i = availableItems.Count - 1; i > 0; i--)
//            {
//                int j = Random.Range(i + 1);
//                // Swap the items at indices i and j
//                Things temp = availableItems[i];
//                availableItems[i] = availableItems[j];
//                availableItems[j] = temp;
//            }

//            // Now take the first 'itemCount' items from the shuffled list
//            for (int i = 0; i < itemCount && i < availableItems.Count; i++)
//            {
//                selectedItems.Add(availableItems[i]);
//            }
//            Debug.Log("You search the Treasure Room and find the following items:");

//            foreach (var item in selectedItems)
//            {
//                Debug.Log($"- {item.Name}: {item.Description}");
//                Console.Write($"Do you want to pick up {item.Name}? (yes/no): ");
//                string response = Console.ReadLine() ?? "".ToLower();

//                if (response == "yes")
//                {
//                    GameManager.player.inventory.AddItem(item);
//                    Debug.Log($"{item.Name} has been added to your inventory.");
//                    ShowInventory(GameManager.player.inventory); // Show inventory immediately after picking up
//                }
//                else
//                {
//                    Debug.Log($"{item.Name} has been left behind.");
//                }
//            }
//        }

//        public override void OnExited()
//        {
//            Debug.Log("You leave the Treasure Room, your pockets filled with treasures!");
//            ShowInventory(GameManager.player.inventory); // Show inventory before exiting
//            ShowAvailableDirections(this);
//        }

//        private void ShowInventory(Inventory inventory)
//        {
//            Debug.Log("Your inventory contains:");
//            foreach (var item in inventory.things)
//            {
//                Debug.Log($"- {item.Name}: {item.Description}");
//            }
//        }

//        public void ShowAvailableDirections(Room currentRoom)
//        {
//            Debug.Log("Available directions:");

//            // Only show connections that are not the current room
//            foreach (var direction in currentRoom.Connections)
//            {
//                // Show the direction if it's valid
//                if (direction.Value.RoomNumber != currentRoom.RoomNumber)
//                {
//                    Debug.Log($"- {direction.Key} to Room {direction.Value.RoomNumber}");
//                }
//            }

//            // Ask the player to pick a direction
//            Console.Write("Which direction do you want to go? ");
//            string chosenDirection = Console.ReadLine()?.ToLower();

//            // Check if the chosen direction is valid
//            if (currentRoom.Connections.ContainsKey(chosenDirection))
//            {
//                Room nextRoom = currentRoom.Connections[chosenDirection];
//                currentRoom = nextRoom; // Move to the next room
//                Debug.Log($"You have moved to Room {currentRoom.RoomNumber}");
//            }
//            else
//            {
//                Debug.Log("Invalid direction. Please choose a valid direction.");
//            }
//        }
//    }
//}

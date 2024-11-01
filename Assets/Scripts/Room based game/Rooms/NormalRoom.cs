//using UnityEngine;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace GD12_1133_A2_SreejaYathipathi
//{
//    public class NormalRoom : Room
//    {
//        private List<Things> availableItems = new List<Things>
//        {
//            new Dagger(),
//            new SmallHealingPotion()
//        };

//        public NormalRoom() : base("Normal") { }

//        public override void OnEntered()
//        {
//            Debug.Log("You have entered a Normal Room. It seems uneventful.");
//            Debug.Log("Do you want to search the room?");
//            Debug.Log("Please enter 'yes' or 'no'");
//            string normalsearchchoice = Console.ReadLine()?.ToLower();
//            while (normalsearchchoice != "yes" && normalsearchchoice != "no")
//            {
//                Debug.Log("Please enter 'yes' or 'no'");
//                normalsearchchoice = Console.ReadLine()?.ToLower();
//            }
//            if (normalsearchchoice == "yes")
//            {
//                OnSearched();
//            }
//            else if (normalsearchchoice == "no")
//            {
//                Debug.Log("You chose not to search the room.");
//            }
//        }

//        public override void OnSearched()
//        {
//            Random random = new Random();
//            int itemCount = Random.Range(1, 3);

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
//            Debug.Log("You search the Normal Room and find the following items:");
//            foreach (var item in selectedItems)
//            {
//                Debug.Log($"- {item.Name}: {item.Description}");
//                Console.Write($"Do you want to pick up {item.Name}? (yes/no): ");
//                string response = Console.ReadLine()?.ToLower();

//                if (response == "yes")
//                {
//                    GameManager.player.inventory.AddItem(item);
//                    Debug.Log($"{item.Name} has been added to your inventory.");
//                }
//                else
//                {
//                    Debug.Log($"{item.Name} has been left behind.");
//                }
//            }
//        }

//        public override void OnExited()
//        {
//            Debug.Log("You exit the Normal Room.");
//            ShowInventory();
//            ShowAvailableDirections(GameManager.mapGenerator.currentRoom);
//        }

//        private void ShowInventory()
//        {
//            Debug.Log("Your inventory contains:");
//            foreach (var item in GameManager.player.inventory.things)
//            {
//                Debug.Log($"- {item.Name}: {item.Description}");
//            }
//        }

//        private void ShowAvailableDirections(Room currentRoom)
//        {
//            Debug.Log("Available directions:");
//            foreach (var direction in currentRoom.Connections)
//            {
//                if (direction.Value.RoomNumber != currentRoom.RoomNumber) // Avoid showing the current room
//                {
//                    Debug.Log($"- {direction.Key} to Room {direction.Value.RoomNumber}");
//                }
//            }

//            // Ask the player to pick a direction
//            Console.Write("Which direction do you want to go? ");
//            string chosenDirection = Console.ReadLine()?.ToLower();

//            if (currentRoom.Connections.ContainsKey(chosenDirection))
//            {
//                Room nextRoom = currentRoom.Connections[chosenDirection];
//                currentRoom = nextRoom;
//                Debug.Log($"You have moved to Room {currentRoom.RoomNumber}");
//            }
//            else
//            {
//                Debug.Log("Invalid direction. Please choose a valid direction.");
//            }
//        }
//    }
//}

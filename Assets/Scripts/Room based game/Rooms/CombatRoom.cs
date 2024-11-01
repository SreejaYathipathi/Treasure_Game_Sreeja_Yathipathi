//using UnityEngine;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GD12_1133_A2_SreejaYathipathi
//{
//    public class CombatRoom : Room
//    {
//        private Enemy enemy;
//        private Player player;

//        public CombatRoom(Player player) : base("Combat")
//        {
//            this.player = player;
//            enemy = GenerateEnemy(); // Generate a random enemy for combat
//        }

//        public override void OnEntered()
//        {
//            Debug.Log("You have entered the Combat Room! A fierce enemy stands before you.");
//            ShowInventory();
//            PlayerTurn();
//        }

//        public override void OnSearched()
//        {
//            Debug.Log("You are already in combat! Prepare to fight!");
//        }

//        public override void OnExited()
//        {
//            Debug.Log("You cannot leave the combat room until the enemy is defeated!");
//        }

//        private void ShowInventory()
//        {
//            Debug.Log("Available items in your inventory:");
//            foreach (var item in GameManager.player.inventory.things)
//            {
//                Debug.Log($"- {item.Name}: {item.Description}");
//            }
//            PlayerTurn();
//        }

//        private void PlayerTurn()
//        {
//            Console.Write("Select an item from your inventory to use or attack (enter the name): ");
//            string input = Console.ReadLine() ?? "";

//            Things? selectedItem = null;
//            for (int i = 0; i < GameManager.player.inventory.things.Count; i++)
//            {
//                if (GameManager.player.inventory.things[i].Name.Equals(input, StringComparison.OrdinalIgnoreCase))
//                {
//                    selectedItem = GameManager.player.inventory.things[i];
//                    break; // Exit the loop once we find the item
//                }
//            }

//            if (selectedItem != null)
//            {
//                if (selectedItem is Consumable consumable)
//                {
//                    Console.Write($"Do you want to drink {consumable.Name}? (yes/no): ");
//                    string response = Console.ReadLine() ?? "".ToLower();

//                    if (response == "yes")
//                    {
//                        player.ConsumePotion(consumable);
//                        Debug.Log($"{consumable.Name} has been consumed.");
//                    }
//                    else
//                    {
//                        ShowInventory();
//                    }
//                }
//                else if (selectedItem is Weapon weapon)
//                {
//                    Console.Write("Choose attack type (z, x, c): ");
//                    char attackType = Console.ReadKey().KeyChar;
//                    Debug.Log();

//                    int damage = weapon.Attack(attackType);
//                    if (damage > 0)
//                    {
//                        Debug.Log($"You attack the {enemy.Name} with your {weapon.Name} for {damage} damage!");
//                        enemy.TakeDamage(damage);
//                        weapon.DecreaseHP();

//                        if (weapon.IsBroken())
//                        {
//                            GameManager.player.inventory.RemoveItem(weapon); // Remove broken weapon from inventory
//                        }

//                        if (enemy.Health <= 0)
//                        {
//                            Debug.Log($"You have defeated the {enemy.Name}!");
//                            ShowInventory(); // Show inventory after defeating enemy
//                            ShowAvailableDirections(GameManager.mapGenerator.currentRoom);
//                        }
//                        else
//                        {
//                            EnemyTurn();
//                        }
//                    }
//                    else
//                    {
//                        Debug.Log("Invalid attack type. Please select z, x, or c.");
//                        PlayerTurn(); // Prompt player again
//                    }
//                }
//                else
//                {
//                    Debug.Log("That item cannot be used in combat.");
//                    ShowInventory();
//                }
//            }
//            else
//            {
//                Debug.Log("You can't take that because it's not in your inventory.");
//                ShowInventory();
//            }
//        }

//        private void EnemyTurn()
//        {
//            Debug.Log($"{enemy.Name} attacks you!");
//            player.TakeDamage(enemy.AttackPower);

//            if (player.Health <= 0)
//            {
//                Debug.Log("You have died in battle. Game Over!");
//                Environment.Exit(0); // Exits the game
//            }
//            else
//            {
//                Debug.Log($"You have {player.Health} health remaining.");
//                ShowInventory();
//            }
//        }

//        private Enemy GenerateEnemy()
//        {
//            // Randomly generate an enemy type
//            Random random = new Random();
//            int enemyType = Random.Range(1, 5); // 1 to 4 for four enemy types
//            switch (enemyType)
//            {
//                case 1: return new WaterEnemy();
//                case 2: return new AirEnemy();
//                case 3: return new FireEnemy();
//                case 4: return new EarthEnemy();
//                default: throw new InvalidOperationException("Invalid enemy type generated."); // Should not reach here
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

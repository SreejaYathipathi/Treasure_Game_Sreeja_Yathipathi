using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    [SerializeField] private InGameHUD gameHud;
    [SerializeField] private UIManager uiManager;

    private bool isPlayerTurn = true;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Method to start combat
    public void StartCombat()
    {
        // Ensure the inventory stays open (if required)
        uiManager.ShowInventoryPanel();

        // Enable enemy health display
        EnemyManager.Instance.gameObject.SetActive(true);

        // Start the combat loop (Player's turn to start)
        isPlayerTurn = true;
    }

    // Method to handle the player's turn
    public void PlayerTurn()
    {
        if (isPlayerTurn)
        {
            // Get the selected weapon and potion from the inventory
            Weapons selectedWeapon = InventoryManager.Instance.GetSelectedWeapon();
            Potions selectedPotion = InventoryManager.Instance.GetSelectedPotion();

            // Use the selected weapon if available
            if (selectedWeapon != null)
            {
                EnemyManager.Instance.TakeDamage(selectedWeapon.Values); // Apply weapon damage to the enemy
                selectedWeapon.UseItem();  // Reduce weapon durability after use
            }

            // Use the selected potion if available
            if (selectedPotion != null)
            {
                gameHud.IncreaseHealth(selectedPotion.Values); // Heal player using potion
                selectedPotion.UseItem();  // Consume potion
            }

            // After the player attacks, switch to the enemy's turn
            isPlayerTurn = false;
            StartCoroutine(EnemyTurn()); // Call enemy turn coroutine
        }
    }

    // Method to handle the enemy's turn
    private IEnumerator EnemyTurn()
    {
        // Simulate enemy attack (simple random damage for now)
        yield return new WaitForSeconds(1.0f); // Delay for turn transition

        // Enemy deals damage to the player
        int damage = Random.Range(5, 15);  // Random damage value for enemy
        gameHud.DecreaseHealth(damage);  // Decrease player health based on enemy attack

        // Check if the player has lost (Health <= 0)
        if (gameHud.Health <= 0)
        {
            uiManager.PlayerLostPanel(); // Show the lose panel
            yield break;
        }

        // Switch back to the player's turn
        isPlayerTurn = true;
    }

    // Method to check if the combat is over
    public void CheckCombatOutcome()
    {
        // If player's health is 0, display the lose panel
        if (gameHud.Health <= 0)
        {
            uiManager.PlayerLostPanel();
        }
        // If enemy's health is 0, display the win panel
        else if (EnemyManager.Instance.GetEnemyHealth() <= 0)
        {
            uiManager.PlayerWonPanel();
        }
    }
}

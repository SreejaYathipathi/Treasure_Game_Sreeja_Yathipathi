using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [SerializeField] private int enemyHealth = 50;
    private InGameHUD gameHud;  // Reference to GameHUD

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        // Find the GameHUD instance if not directly assigned
        gameHud = FindObjectOfType<InGameHUD>(); // Or directly assign from the inspector if possible
        UpdateEnemyHealthText();
    }

    // Method to deal damage to the enemy
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        UpdateEnemyHealthText();

        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
            gameObject.SetActive(false);  // Hide enemy
        }
    }

    // Method to get enemy's current health
    public int GetEnemyHealth()
    {
        return enemyHealth;
    }

    // Update the enemy health text in the GameHUD
    private void UpdateEnemyHealthText()
    {
        if (gameHud != null)
        {
            gameHud.DecreaseHealth(enemyHealth);  // Make sure to call GameHUD method to update the text
        }
        else
        {
            Debug.LogWarning("GameHUD not found. Enemy health text could not be updated.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private UIManager _uiManager;  // Reference to the UIManager
    public int startingHealth = 100;     // Default health for the enemy, editable in the Inspector
    private int currentHealth;     // Tracks current health of the enemy
    public static Enemy Instance;


    private void Awake()
    {
        // Ensure UIManager reference is set
        _uiManager = FindObjectOfType<UIManager>();

        Instance = this;
    }

    private void Start()
    {
        // Initialize current health to the starting value
        currentHealth = startingHealth;

        _uiManager.EnemyHealthPoints.text = $"{currentHealth}";
    }

    // This method will be called when the enemy takes damage
    public void TakeDamage(int damage)
    {
        // Decrease health by the damage amount
        //currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth - damage);
        _uiManager.EnemyHealthPoints.text = $"{currentHealth}";

        // Update the UI with the new health value
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            _uiManager.EnemyHealthPanel.gameObject.SetActive(false);
        }

    }


    // Optionally, you can expose a method to set a custom health value for testing or flexibility
    public void SetHealth(int health)
    {
        currentHealth = health;
        _uiManager.EnemyHealthPoints.text = $"{currentHealth}";
    }
}

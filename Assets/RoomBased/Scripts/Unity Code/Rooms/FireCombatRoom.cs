using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : RoomBase
{
    private CombatManager combatManager; // Reference to CombatManager
    private EnemyManager enemyManager; // Reference to EnemyManager
    private InGameHUD gameHud; // Reference to GameHUD
    private UIManager _uiManager; // Reference to UIManager
    private bool _hasBeenSearched = false; // Tracks if the treasure room has been searched
    private bool _isPlayerInside = false; // Tracks if the player is inside the treasure room

    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();  // Only need to use this for UIManager as it's not a singleton

    }

    public override void OnRoomEntered()
    {
        Debug.Log("You have entered the Fire combat room.");

        // Ensure all singleton components are available
        // Access the singleton instances directly
        combatManager = CombatManager.Instance;
        enemyManager = EnemyManager.Instance;
        gameHud = InGameHUD.Instance;

        // Ensure all singleton components are available
        if (combatManager == null)
        {
            Debug.LogError("combatManager is not set up correctly.");
        }
        if (enemyManager == null)
        {
            Debug.LogError("enemyManager is not set up correctly.");
        }
        if (gameHud == null)
        {
            Debug.LogError("gameHud is not set up correctly.");
        }
        if (_uiManager == null)
        {
            Debug.LogError("_uiManager is not set up correctly.");
        }

        if (!_hasBeenSearched)
        {
            _isPlayerInside = true;
            _uiManager.FireCombatPanel(); // Show the combat panel
        }
    }

    public override void OnRoomSearched()
    {
        Debug.Log("You can't search the combat room!");
    }

    public override void OnRoomExited()
    {
        Debug.Log("You have exited the Fire combat room.");

        _isPlayerInside = false;

        // Ensure no UI panels remain active when leaving
        if (!_hasBeenSearched)
        {
            _uiManager.SetLayout(UIManager.MenuLayouts.InGame); // Close the combat panel if not searched
        }

        // Reset the room if needed, disable the enemy, etc.
        ResetCombat();
    }

    private void Update()
    {
        if (_isPlayerInside && !_hasBeenSearched)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Player chooses to start combat
            {
                StartCombat();
            }
            else if (Input.GetKeyDown(KeyCode.R)) // Player declines combat
            {
                DeclineCombat();
            }
        }
    }

    private void StartCombat()
    {
        // Activate the enemy and display its health and inventory
        enemyManager.gameObject.SetActive(true);

        // Start the combat manager to trigger combat flow
        combatManager.StartCombat();
    }

    private void DeclineCombat()
    {
        _uiManager.NoSearchPanel();
    }

    private void ResetCombat()
    {
        // Reset or disable components when exiting the room
        enemyManager.gameObject.SetActive(false);  // Hide the enemy
    }
}

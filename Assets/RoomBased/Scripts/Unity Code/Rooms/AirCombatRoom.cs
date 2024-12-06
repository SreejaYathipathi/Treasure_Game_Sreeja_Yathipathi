using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCombatRoom : RoomBase
{
    private UIManager _uiManager;
    private bool _hasBeenSearched = false; // Tracks if the treasure room has been searched
    private bool _isPlayerInside = false; // Tracks if the player is inside the treasure room
    public GameObject enemy;


    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();

    }

    public override void OnRoomEntered()
    {
        Debug.Log("You have entered the Air Combat Room room.");

        if (!_hasBeenSearched)
        {
            _isPlayerInside = true;

            _uiManager.AirCombatPanel(); // Show the treasure search panel
        }

    }

    private void Update()
    {
        // Continuously check for the 'E' key press while in the combat room
        if (_isPlayerInside && enemy != null && !enemy.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            ShowEnemy();
            _uiManager.EnemyHealthPanel.gameObject.SetActive(true);
        }
    }


    private void ShowEnemy()
    {
        // Make the enemy visible when 'E' is pressed
        enemy.SetActive(true);
        Debug.Log("Enemy is now visible and ready for combat.");
        _hasBeenSearched = true;

        // Optionally, close the combat panel or do any other UI updates
        _uiManager.SetLayout(UIManager.MenuLayouts.InGame); // Example: Close the combat panel after the enemy is shown
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Combat room cannot be searched!");
    }

    public override void OnRoomExited()
    {
        Debug.Log("You have exited the Air Combat Room room.");

        _isPlayerInside = false;

        enemy.SetActive(false);
        _uiManager.EnemyHealthPanel.gameObject.SetActive(false);


        // Ensure no UI panels remain active when leaving
        if (!_hasBeenSearched)
        {
            _uiManager.SetLayout(UIManager.MenuLayouts.InGame); // Close the combat panel if not searched
        }


    }
}

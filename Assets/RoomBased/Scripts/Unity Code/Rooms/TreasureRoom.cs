using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : RoomBase
{
    private UIManager _uiManager;
    private bool _hasBeenSearched = false; // Tracks if the treasure room has been searched
    private bool _isPlayerInside = false; // Tracks if the player is inside the treasure room
    [SerializeField] private GameObject[] items; // Items to reveal after searching, assignable in Inspector

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
        Debug.Log("You have entered the treasure room.");

        if (!_hasBeenSearched)
        {
            _isPlayerInside = true;
            
            _uiManager.TreasureSearchPanel(); // Show the treasure search panel
        }
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Treasure Room Searched. You found a bag full of treasure!");

        // Set the treasure room's searched state and reveal items
        _hasBeenSearched = true;

        foreach (var item in items)
        {
            item.SetActive(true); // Make items visible
        }
    }

    public override void OnRoomExited()
    {
        Debug.Log("You have exited the treasure room.");
        _isPlayerInside = false;

        // Ensure no UI panels remain active when leaving
        if (!_hasBeenSearched)
        {
            _uiManager.SetLayout(UIManager.MenuLayouts.InGame); // Close the treasure panel if not searched
        }
    }

    private void Update()
    {
        if (_isPlayerInside && !_hasBeenSearched)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Player chooses to search
            {
                SearchTreasure();
            }
            else if (Input.GetKeyDown(KeyCode.R)) // Player declines to search
            {
                DeclineSearch();
            }
        }
    }

    private void SearchTreasure()
    {
        Debug.Log("Player chose to search the room.");

        // Disable the treasure search panel
        _uiManager.SetLayout(UIManager.MenuLayouts.InGame);

        // Call the base OnRoomSearched logic
        OnRoomSearched();
    }

    private void DeclineSearch()
    {
        Debug.Log("You chose not to search the treasure room.");

        // Show the "No Search" panel
        _uiManager.NoSearchPanel();

        _hasBeenSearched = true; // Mark the room as used, even if declined
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : RoomBase
{
    [SerializeField] public GameObject interactionPanel; // Assign the Panel in the Inspector
    private bool isPlayerInside = false; // Track if the player is inside the trigger

    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("You have entered the treasure room.");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Treasure Room Searched. You found a bag full of treasure.");
    }

    public override void OnRoomExited()
    {
        Debug.Log("You have exited the treasure room.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            OnRoomEntered(); // Call OnRoomEntered when entering
            interactionPanel.SetActive(true); // Show the interaction panel
            isPlayerInside = true; // Set the flag
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnRoomExited(); // Call OnRoomExited when exiting
            interactionPanel.SetActive(false); // Hide the interaction panel
            isPlayerInside = false; // Reset the flag
        }
    }

    void Update()
    {
        if (isPlayerInside)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Player presses 'E'
            {
                OnRoomSearched(); // Call OnRoomSearched
                interactionPanel.SetActive(false); // Hide the panel
            }
            else if (Input.GetKeyDown(KeyCode.R)) // Player presses 'R'
            {
                Debug.Log("Player chose NOT to search the treasure room.");
                interactionPanel.SetActive(false); // Hide the panel
            }
        }
    }

    void SearchTreasureRoom()
    {
        Debug.Log("Searching the treasure room...");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCombatRoom : RoomBase
{
    public DiceGameManager diceGameManager; // Reference to the DiceGameManager script
    public GameObject combatPanel;       // Main panel for "Start or Instructions"
    public GameObject instructionsPanel; // Instructions panel
    private bool isPlayerInside = false; // Track if the player is inside the trigger

    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("You have entered the Earth combat room.");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("you can't search combat room.!");
    }

    public override void OnRoomExited()
    {
        Debug.Log("You have exited the Earth combat room.");
    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            OnRoomEntered();             // Call the base behavior
//            combatPanel.SetActive(true); // Show the main panel
//            isPlayerInside = true;
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            OnRoomExited();              // Call the base behavior
//            combatPanel.SetActive(false); // Hide both panels when leaving
//            instructionsPanel.SetActive(false);
//            isPlayerInside = false;
//        }
//    }

//    void Update()
//    {
//        if (isPlayerInside)
//        {
//            if (Input.GetKeyDown(KeyCode.E)) // Start the combat room
//            {
//                Debug.Log("Combat Room Started!");
//                combatPanel.SetActive(false); // Hide the main panel
//                diceGameManager.StartDiceGame();
//            }
//            else if (Input.GetKeyDown(KeyCode.R)) // Show instructions
//            {
//                combatPanel.SetActive(false);    // Hide the main panel
//                instructionsPanel.SetActive(true); // Show the instructions panel
//            }
//        }
//    }

//    public void BackToCombatPanel()
//    {
//        instructionsPanel.SetActive(false); // Hide the instructions panel
//        combatPanel.SetActive(true);        // Show the main panel
//    }
}

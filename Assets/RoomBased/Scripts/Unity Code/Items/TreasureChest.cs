using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public Animator chestAnimator; // Assign the Animator in the Inspector
    private bool isOpen = false;   // Tracks the state of the chest
    private bool isPlayerNearby = false;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    ToggleChest();
        //}

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            ToggleChest();
        }
    }

    void ToggleChest()
    {
        isOpen = !isOpen; // Toggle the state
        chestAnimator.SetBool("IsOpen", isOpen); // Update Animator parameter
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

}

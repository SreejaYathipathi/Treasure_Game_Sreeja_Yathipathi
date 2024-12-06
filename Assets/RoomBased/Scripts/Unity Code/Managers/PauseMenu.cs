using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // Assign the Panel (Pause Menu)
    private bool _isPaused = false;

    List<ItemData> _inventoryItems = new();

    List<InventoryManager> _inventoryItemInstance = new();

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    

    public void TogglePause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0; // Pause the game
            pauseMenu.SetActive(true); // Show the pause menu
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Make the cursor visible
        }
        else
        {
            Time.timeScale = 1; // Resume the game
            pauseMenu.SetActive(false); // Hide the pause menu
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor back
            Cursor.visible = false; // Hide the cursor
        }
    }

    public void ButtonResume()
    {
        _isPaused = false;
        Time.timeScale = 1; // Resume the game
        pauseMenu.SetActive(false); // Hide the pause menu
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ButtonRestart()
    {
        Time.timeScale = 1; // Ensure the game is running
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void ButtonQuit()
    {
        Time.timeScale = 1; // Ensure the game is running
        Application.Quit(); // Quit the application
    }
}

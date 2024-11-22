using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Transform InventoryContentParent;
    [SerializeField] private InventoryItem ItemPrefab;

    public GameObject pauseMenu; // Assign the Panel (Pause Menu)
    private bool isPaused = false;

    List<ItemData> _inventoryItems = new();

    List<InventoryItem> _inventoryItemInstance = new();

    private void Awake()
    {
        //Create some example items for testing
        _inventoryItems.Add(new ItemData("Longsword", ItemData.Rarity.Common));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void OnEnable()
    {
        foreach(ItemData item in _inventoryItems)
        {
            var inventoryItem = Instantiate(ItemPrefab, InventoryContentParent);
            //inventoryItem.Setup(item);
            _inventoryItemInstance.Add(inventoryItem);
        }
    }

    private void OnDisable()
    {
        foreach(InventoryItem item in _inventoryItemInstance)
        {
            //Destroy(item.gameobject);
        }

        _inventoryItemInstance.Clear();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
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
        isPaused = false;
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
                            // If testing in the Unity Editor, stop play mode:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager GameMapPrefab;
    [SerializeField] private PlayerMovement Playerprefab;

    private MapManager _gameMap;
    private PlayerMovement _playerMovement;
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("Game has started....");
        // Zero our manager position
        transform.position = Vector3.zero;

        SetupMap();
        SpawnPlayer();
    }

    private void SetupMap()
    {
        Debug.Log("GameManager SetupMap Begins");
        // create an instance of the map manager
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;
        // create the map
        _gameMap.CreateMap();
        Debug.Log("GameManager Setup Complete");
    }

    private void SpawnPlayer()
    {
        // Intro
        Debug.Log("GameManager SpawnPlayer Begins");
        // Pick a random starting room - this must be done only after the map is created
        var randomStartingRoom = _gameMap.Rooms.ElementAt(Random.Range(0, _gameMap.Rooms.Keys.Count));
        // Create the player
        _playerMovement = Instantiate(Playerprefab, transform);
        // Set their initial position
        _playerMovement.transform.position = new Vector3(randomStartingRoom.Key.x, 0, randomStartingRoom.Key.y);
        // Call the Player Setup Function
        // _playerMovement.Setup();
        Debug.Log("GameManager SpawnPlayer Complete");
    }
}

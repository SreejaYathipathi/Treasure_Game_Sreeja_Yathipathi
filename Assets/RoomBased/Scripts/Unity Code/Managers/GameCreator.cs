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
        _gameMap.CreateMap(this);
        Debug.Log("GameManager Setup Complete");
    }

    private void SpawnPlayer()
    {
        // Intro
        Debug.Log("GameManager SpawnPlayer Begins");
        var startingRoom = _gameMap.Rooms[new Vector2(0, 0)];
        // Create the player
        _playerMovement = Instantiate(Playerprefab, transform);
        // Set their initial position
        _playerMovement.transform.position = new Vector3(startingRoom.transform.position.x, 0, startingRoom.transform.position.z);
        Debug.Log("GameManager SpawnPlayer Complete");
    }
}

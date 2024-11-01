using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager GameMapPrefab;

    private MapManager _gameMap;
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("Game has started....");
        // Zero our manager position
        transform.position = Vector3.zero;

        // create an instance of the map manager
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;
        // create the map
        _gameMap.CreateMap();

        Debug.Log("GameCreator has created a map.");

        StartGame();
    }

    private void StartGame()
    {
        Debug.Log("Hello");
        var randomStartingRoom = _gameMap._rooms.ElementAt(Random.Range(0, _gameMap._rooms.Keys.Count));
        // Set the camera tothe spawn room
        Camera.main.transform.position = new Vector3(randomStartingRoom.Key.x, 2.5f, randomStartingRoom.Key.y);
    }
}

using System.Collections.Generic;

using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private RoomBase[] RoomPrefabs;

    private GameManager _gameManager;

    private const float _roomSize = 15;
    private int _mapSize = 5;

    readonly Dictionary<Vector2, RoomBase> _rooms = new();
    public Dictionary<Vector2, RoomBase> Rooms => _rooms;

    public void CreateMap(GameManager manager)
    {
        _gameManager = manager;
        for (int x = 0; x < _mapSize; x++)
        {
            for (int z = 0; z < _mapSize; z++)
            {
                Vector2 coords = new Vector2(x * _roomSize, z * _roomSize);
                RoomBase roomInstance;
                if (x == 0 && z == 0)
                {
                    roomInstance = Instantiate(RoomPrefabs[0], transform);
                }
                else if (IsAdjacentToStart(x, z))
                {
                    // Treasure rooms adjacent to the start room
                    roomInstance = Instantiate(RoomPrefabs[1], transform);
                }
                else
                {
                    roomInstance = Instantiate(RoomPrefabs[Random.Range(1, RoomPrefabs.Length)], transform);
                }

                roomInstance.SetRoomLocation(coords);
                _rooms.Add(coords, roomInstance);
            }
        }

        foreach (var roomByCoordinate in _rooms)
        {
            RoomBase northRoom = FindRoom(roomByCoordinate.Key, Direction.North);
            RoomBase eastRoom = FindRoom(roomByCoordinate.Key, Direction.East);
            RoomBase southRoom = FindRoom(roomByCoordinate.Key, Direction.South);
            RoomBase westRoom = FindRoom(roomByCoordinate.Key, Direction.West);

            roomByCoordinate.Value.SetRooms(northRoom, eastRoom, southRoom, westRoom);
        }
    }

    private bool IsAdjacentToStart(int x, int z)
    {
        // Adjacent rooms are one step away from the starting room (0, 0)
        return (Mathf.Abs(x - 0) == 1 && z == 0) || (x == 0 && Mathf.Abs(z - 0) == 1);
    }

    private RoomBase FindRoom(Vector2 currentRoom, Direction direction)
    {
        RoomBase room = null;
        Vector2 nextRoomCoordinates = new Vector2(-1, -1);

        switch (direction)
        {
            case Direction.North:
                // Determine North Room
                nextRoomCoordinates = currentRoom + (Vector2.up * _roomSize);
                break;
            case Direction.East:
                // east
                nextRoomCoordinates = currentRoom + (Vector2.right * _roomSize);
                break;
            case Direction.South:
                // south
                nextRoomCoordinates = currentRoom + (Vector2.down * _roomSize);
                break;
            case Direction.West:
                // west
                nextRoomCoordinates = currentRoom + (Vector2.left * _roomSize);
                break;
        }

        if (_rooms.TryGetValue(nextRoomCoordinates, out var nextRoom))
        {
            room = nextRoom;
        }

        return room;
    }
}

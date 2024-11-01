using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private RoomBase[] RoomPrefabs;
    [SerializeField] private Vector2 RoomSize;

    private int MapSize = 9;
    public Dictionary<Vector3, RoomBase> _rooms = new Dictionary<Vector3, RoomBase>();
    public void CreateMap()
    {
        for (int x = 0; x < MapSize; x++)
        {
            for (int y = 0; y < MapSize; y++)
            {
                Vector2 coords = new Vector2(x * RoomSize.x, y * RoomSize.y);
                Vector3 position = new Vector3(coords.x, 0, coords.y);

                var roomInstance = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)], transform);

                roomInstance.SetRoomLocation(position);

                _rooms.Add(position, roomInstance);
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

    public enum Direction
    {
        North,
        South,
        East,
        West,
    }

    private RoomBase FindRoom(Vector2 currentRoom, Direction direction)
    {
        RoomBase room = null;

        Vector2 nextRoomCoordinates = new Vector2(-1, -1);
        switch (direction)
        {
            case Direction.North:
                // Determine North Room
                nextRoomCoordinates = currentRoom + (Vector2.up * RoomSize);
                break;
            case Direction.East:
                // east
                nextRoomCoordinates = currentRoom + (Vector2.right * RoomSize);
                break;
            case Direction.South:
                // south
                nextRoomCoordinates = currentRoom + (Vector2.down * RoomSize);
                break;
            case Direction.West:
                // west
                nextRoomCoordinates = currentRoom + (Vector2.left * RoomSize);
                break;
        }

        if (_rooms.TryGetValue(nextRoomCoordinates, out var nextRoom))
        {
            room = nextRoom;
        }
        return room;
    }
}

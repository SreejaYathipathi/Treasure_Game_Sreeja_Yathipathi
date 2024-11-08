using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBase : MonoBehaviour
{
    [SerializeField] private GameObject NorthDoorway, EastDoorway, SouthDoorway, WestDoorway;

    private RoomBase _north, _south, _east, _west;

    public RoomBase North => _north;
    public RoomBase East => _east;
    public RoomBase South => _south;
    public RoomBase West => _west;

    private Vector2 _roomPosition;
    public Vector2 RoomPosition => _roomPosition;

    public virtual void SetRoomLocation(Vector2 coordinates)
    {
        transform.position = new Vector3(coordinates.x, 0, coordinates.y);
        _roomPosition = coordinates;
    }

    public void SetRooms(RoomBase roomNorth, RoomBase roomEast, RoomBase roomSouth, RoomBase roomWest)
    {
        _north = roomNorth;
        NorthDoorway.SetActive(_north == null);

        _east = roomEast;
        EastDoorway.SetActive(_east == null);

        _south = roomSouth;
        SouthDoorway.SetActive(_south == null);

        _west = roomWest;
        WestDoorway.SetActive(_west == null);
    }

    public virtual void OnRoomEntered()
    {
        Debug.Log("You have entered the normal room.");
    }

    public virtual void OnRoomSearched()
    {
        Debug.Log("You have searched the normal room.");
    }

    public virtual void OnRoomExited()
    {
        Debug.Log("You have exited the normal room.");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player object has the "Player" tag
        {
            OnRoomEntered();
        }
    }

    // Detect player exit
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnRoomExited();
        }
    }
}

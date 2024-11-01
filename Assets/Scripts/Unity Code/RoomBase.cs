using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBase : MonoBehaviour
{
    [SerializeField] private GameObject NorthDoorway, EastDoorway, SouthDoorway, WestDoorway;

    private RoomBase _north, _south, _east, _west;

    public virtual void SetRoomLocation(Vector3 position)
    {
        transform.position = position;
    }
    public void SetRooms(RoomBase roomNorth, RoomBase roomSouth, RoomBase roomEast, RoomBase roomWest)
    {
        _north = roomNorth;
        NorthDoorway.SetActive(_north == null);
        _south = roomNorth;
        SouthDoorway.SetActive(_south == null);
        _east = roomNorth;
        EastDoorway.SetActive(_east == null);
        _west = roomNorth;
        WestDoorway.SetActive(_west == null);
    }
}

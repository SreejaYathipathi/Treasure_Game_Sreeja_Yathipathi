using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : RoomBase
{
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("You have entered the Fire combat room.");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("you can't search combat room.!");
    }

    public override void OnRoomExited()
    {
        Debug.Log("You have exited the Fire combat room.");
    }
}

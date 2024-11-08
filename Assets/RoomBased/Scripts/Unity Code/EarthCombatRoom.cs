using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCombatRoom : RoomBase
{
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("You have entered the Earth combat room.");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("you can't search combat room.!");
    }

    public override void OnRoomExited()
    {
        Debug.Log("You have exited the Earth combat room.");
    }
}

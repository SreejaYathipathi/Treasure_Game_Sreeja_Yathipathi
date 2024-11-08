using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : RoomBase
{
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("You have entered the treasure room.");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Treasure Room Searched. You found a bag full of treasure.");
    }

    public override void OnRoomExited()
    {
        Debug.Log("You have exited the treasure room.");
    }
}

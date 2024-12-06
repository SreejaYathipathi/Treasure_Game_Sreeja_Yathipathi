using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : ItemData
{
    public int healingAmount; // How much health the potion heals
    //private InGameHUD GameHud;

    void Start()
    {
        //Set healing amount based on potion type(small, medium, large)
    }

    public override int Values
    {
        get
        {
            Debug.Log($"Accessing {ItemName} Values: {healingAmount}"); // For Potions
            return healingAmount;
        }
    }
}

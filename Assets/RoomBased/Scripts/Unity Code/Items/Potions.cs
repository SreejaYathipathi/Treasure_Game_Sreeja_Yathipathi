using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : ItemData
{
    public int healingAmount; // How much health the potion heals
    private InGameHUD GameHud;

    void Start()
    {
        // Set healing amount based on potion type (small, medium, large)
        if (ItemName == "Small Healing Potion")
        {
            healingAmount = 25;
        }
        else if (ItemName == "Medium Healing Potion")
        {
            healingAmount = 50;
        }
        else if (ItemName == "Large Healing Potion")
        {
            healingAmount = 100;
        }
    }



    public override void UseItem()
    {
        // Use the healing amount as the value
        Debug.Log($"Potion used! Healing {healingAmount} HP.");
        GameHud.IncreaseHealth(healingAmount); // Update health using healingAmount
    }

    public override int Values
    {
        get { return healingAmount; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : ItemData
{

    public int minDamageValue;  // Minimum damage value
    public int maxDamageValue;  // Maximum damage value
    private InGameHUD GameHud;

    public int durability; // Represents the weapon's health or durability
    private int damageValue; // Define the weapon's damage value

    void Start()
    {
        // Log initialized weapon details from the prefab
        Debug.Log($"Weapon initialized: {ItemName} | Rarity: {ItemRarity} | Durability: {durability} | Damage: {minDamageValue} - {maxDamageValue}");

        damageValue = Random.Range(minDamageValue, maxDamageValue + 1);
    }

    public override void UseItem()
    {
        // Simulate using the weapon and reducing its durability
        if (durability > 0)
        {
            durability--;
            Debug.Log($"Weapon used: {ItemName} | Remaining Durability: {durability}");
            GameHud.IncreaseScore(damageValue); // Update score using damageValue
        }
        else
        {
            Debug.Log($"Weapon {ItemName} is broken and cannot be used!");
        }
    }

    public override int Values
    {
        get { return damageValue; }
    }
}

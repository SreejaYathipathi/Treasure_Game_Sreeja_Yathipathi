using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : ItemData
{

    public int minDamageValue;  // Minimum damage value
    public int maxDamageValue;  // Maximum damage value
    //private InGameHUD GameHud;

    private int damageValue; // Define the weapon's damage value

    void Start()
    {
        // Log initialized weapon details from the prefab
        Debug.Log($"Weapon initialized: {ItemName} | Rarity: {ItemRarity} | Damage: {minDamageValue} - {maxDamageValue}");

        damageValue = Random.Range(minDamageValue, maxDamageValue + 1);
        Debug.Log($"Weapon {ItemName} Damage Value Initialized: {damageValue}");
    }

    public override int Values
    {
        get
        {
            Debug.Log($"Accessing {ItemName} Values: {damageValue}"); // For Weapons
            return damageValue;
        }
    }
}

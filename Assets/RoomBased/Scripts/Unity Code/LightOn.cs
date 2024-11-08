using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    Light lg;
    private void Start()
    {
        lg = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lg.intensity = 10; // Turn on the light when the player enters
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lg.intensity = 0; // Turn off the light when the player exits
        }
    }
}

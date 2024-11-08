using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    [SerializeField] private Light lg;
    private void Start()
    {
        lg = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger area."); // Debug log for entry
            lg.intensity = 10; // Turn on the light
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger area."); // Debug log for exit
            lg.intensity = 0; // Turn off the light
        }
    }
}

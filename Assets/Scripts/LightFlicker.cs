using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightFlicker : MonoBehaviour
{
    public Light lampLight;           // Reference to the Light component
    public float flickerInterval = 1.4f; // Interval in seconds for flickering on and off

    private float timer;               // Timer to keep track of flicker interval

    void Start()
    {
        if (lampLight == null)
        {
            lampLight = GetComponent<Light>(); // Automatically assign the Light component if not set
        }
        timer = flickerInterval;               // Start timer at the interval value
    }

    void Update()
    {
        timer -= Time.deltaTime;               // Decrease timer by the time passed since last frame

        if (timer <= 0f)                       // When timer reaches zero or below
        {
            lampLight.enabled = !lampLight.enabled; // Toggle the light on/off
            timer = flickerInterval;           // Reset the timer
        }
    }
}

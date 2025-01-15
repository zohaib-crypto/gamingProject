using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light spotLight; // Assign this in the Inspector to your Spot Light object
    private bool isOn = true;

    void Start()
    {
        if (spotLight == null)
        {
            Debug.LogError("Spot light reference is missing. Please assign it in the Inspector.");
        }
        else
        {
            spotLight.enabled = isOn; // Initial state
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Check if the F key is pressed
        {
            isOn = !isOn; // Toggle the light state
            spotLight.enabled = isOn; // Apply the state to the light component
        }
    }
}

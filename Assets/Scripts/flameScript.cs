using System.Collections;
using UnityEngine;

public class flameScript : MonoBehaviour
{
    public GameObject FlameLight; // Reference to the GameObject holding the Animator component
    private Animator flameAnimator; // Reference to the Animator component
    private int LightMode; // Integer to control animation state

    void Start()
    {
        // Get the Animator component from the FlameLight GameObject
        flameAnimator = FlameLight.GetComponent<Animator>();

        // Check if the animator was found
        if (flameAnimator == null)
        {
            Debug.LogError("Animator component not found on FlameLight GameObject!");
            return;
        }

        // Start the coroutine to animate the light
        StartCoroutine(AnimateLight());
    }

    IEnumerator AnimateLight()
    {
        while (true) // Loop indefinitely to keep animating
        {
            // Generate a random integer between 1 and 3
            LightMode = Random.Range(1, 4);
            Debug.Log("Setting LightMode to: " + LightMode); // Log the value being set

            // Try setting the LightMode parameter in the Animator
            flameAnimator.SetInteger("LightMode", LightMode);

            // Wait for 0.99 seconds before changing the LightMode again
            yield return new WaitForSeconds(0.99f);
        }
    }
}

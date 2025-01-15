using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    private Animator doorAnimator;
    private AudioSource audioSource;

    public AudioClip openSound;  // Audio clip for the door opening sound
    public AudioClip closeSound; // Audio clip for the door closing sound

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && enabled)
        {
            if (doorAnimator)
                doorAnimator.SetBool("IsOpen", true);

            // Play the open sound if it's assigned
            if (openSound != null)
            {
                audioSource.clip = openSound;
                audioSource.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(enabled)
            {
                if (doorAnimator)
                    doorAnimator.SetBool("IsOpen", false);

                // Play the close sound if it's assigned
                if (closeSound != null)
                {
                    audioSource.clip = closeSound;
                    audioSource.Play();
                }
            }
            
        }
            
    }
}

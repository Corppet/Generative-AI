using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtworkInteraction : MonoBehaviour
{
    public AudioClip interactSound;

    public bool hasInteracted = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is the player and interaction hasn't occurred yet
        if (other.CompareTag("Player") && !hasInteracted)
        {
            // Set the flag to indicate that interaction has occurred
            hasInteracted = true;

            // Play the interact sound
            AudioSource.PlayClipAtPoint(interactSound, transform.position);

            // Display a message to the player
            Debug.Log("You interacted with " + gameObject.name);
        }
    }
}

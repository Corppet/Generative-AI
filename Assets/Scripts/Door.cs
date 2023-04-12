using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Transform doorAnchor;
    private Door connectedDoor;

    public void Connect(Door otherDoor)
    {
        connectedDoor = otherDoor;
        otherDoor.connectedDoor = this;
    }

    public void CheckConnection()
    {
        if (connectedDoor == null)
        {
            Debug.Log("Door is not connected.");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Door is connected.");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered door.");

            // Teleport the player to the connected door
            other.transform.position = connectedDoor.doorAnchor.position;
        }
    }
}

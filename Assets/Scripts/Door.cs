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

    public void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // Teleport the player to the connected door
            other.transform.position = connectedDoor.doorAnchor.position;
        }
    }
}

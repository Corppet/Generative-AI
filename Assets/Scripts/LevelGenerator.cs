using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public int maxRooms = 20;
    public int minRoomSize = 5;
    public int maxRoomSize = 20;
    public GameObject[] roomPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Select a random starting room
        GameObject currentRoom = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)]);

        // Keep track of all instantiated rooms
        List<GameObject> instantiatedRooms = new List<GameObject>();
        instantiatedRooms.Add(currentRoom);

        // Generate additional rooms until the maximum number is reached
        for (int i = 0; i < maxRooms; i++)
        {
            // Choose a random door in the current room
            Door[] doors = currentRoom.GetComponentsInChildren<Door>();
            Door chosenDoor = doors[Random.Range(0, doors.Length)];

            // Select a random room prefab
            GameObject newRoomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];

            // Calculate the position of the new room
            Vector3 newPosition = chosenDoor.transform.position - chosenDoor.doorAnchor.localPosition 
                + newRoomPrefab.GetComponentInChildren<Door>().doorAnchor.localPosition;

            // Instantiate the new room
            GameObject newRoom = Instantiate(newRoomPrefab, newPosition, Quaternion.identity);

            // Connect the new room to the current room
            chosenDoor.Connect(newRoom.GetComponentInChildren<Door>());

            // Add the new room to the list of instantiated rooms
            instantiatedRooms.Add(newRoom);

            // Choose the new room as the current room for the next iteration
            currentRoom = newRoom;
        }
    }

}

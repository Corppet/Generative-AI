using UnityEngine;
using System.Collections;

public class ArtHunt : MonoBehaviour
{

    public int totalArtPieces;
    private int collectedArtPieces = 0;

    void Start()
    {
        // Initialize the game with the total number of art pieces to find
        totalArtPieces = GameObject.FindGameObjectsWithTag("ArtPiece").Length;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ArtPiece")
        {
            Destroy(other.gameObject);

            // Call the CollectArtPiece() method in the GameManager
            GameManager.instance.CollectArtPiece();
        }
    }

    void Update()
    {
        // If the player has collected all the art pieces, end the game
        if (collectedArtPieces == totalArtPieces)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // Do something to end the game, such as displaying a victory message or returning to the main menu
    }
}

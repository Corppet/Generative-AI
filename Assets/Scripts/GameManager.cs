using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public Text artPiecesText;
    public GameObject gameOverPanel;
    public float gameOverDelay = 2f;
    private int totalArtPieces;
    private int collectedArtPieces;

    void Start()
    {
        // Get the total number of art pieces to find
        totalArtPieces = GameObject.FindGameObjectsWithTag("ArtPiece").Length;
        UpdateArtPiecesText();
    }

    public void CollectArtPiece()
    {
        // Increase the number of art pieces the player has collected
        collectedArtPieces++;

        // Update the art pieces UI text
        UpdateArtPiecesText();

        // If the player has collected all the art pieces, end the game
        if (collectedArtPieces == totalArtPieces)
        {
            EndGame();
        }
    }

    void UpdateArtPiecesText()
    {
        // Update the art pieces UI text to reflect the number of art pieces the player has collected
        artPiecesText.text = "Art Pieces Collected: " + collectedArtPieces + "/" + totalArtPieces;
    }

    void EndGame()
    {
        // Display the game over panel after a short delay
        StartCoroutine(GameOverDelay());

        // Pause the game
        Time.timeScale = 0f;
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSecondsRealtime(gameOverDelay);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

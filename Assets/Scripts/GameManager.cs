using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [HideInInspector] public bool isInPlay;

    public TMP_Text artPiecesText;
    public TMP_Text timerText;
    public GameObject gameOverPanel;
    public float gameOverDelay = 2f;
    public float startingTimer = 120f;
    private int totalArtPieces;
    private int collectedArtPieces;
    private float timer;

    private void Awake()
    {
        // Make the GameManager a singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        isInPlay = true;
    }

    void Start()
    {
        // Get the total number of art pieces to find
        totalArtPieces = GameObject.FindGameObjectsWithTag("ArtPiece").Length;
        timer = startingTimer;
        UpdateArtPiecesText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }

        CountdownTimer();
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

    void CountdownTimer()
    {
        timer -= Time.deltaTime;
        if (timer > 0f)
        {
            timerText.text = timer.ToString("F2");
        }
        else
        {
            timerText.text = "0.00";
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
        //Time.timeScale = 0f;
        isInPlay = false;
        Cursor.lockState = CursorLockMode.None;
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

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

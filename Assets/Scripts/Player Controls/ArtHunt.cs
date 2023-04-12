using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

[RequireComponent(typeof(AudioSource))]
public class ArtHunt : MonoBehaviour
{
    public AudioClip[] collectSounds;
    public int totalArtPieces;
    private int collectedArtPieces = 0;
    private AudioSource audioSource;

    public void PlayCollect()
    {
        audioSource.PlayOneShot(collectSounds[Random.Range(0, collectSounds.Length)], audioSource.volume);
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            PlayCollect();
        }
    }
}

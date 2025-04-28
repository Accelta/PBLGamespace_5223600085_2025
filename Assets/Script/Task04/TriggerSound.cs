using System.Collections;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioSource audioSource;
    public ScoreManager scoremanager;
    public int pointsToAdd =1;
        void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Play the audio
            if (audioSource != null)
            {
                Debug.Log("Player collided");
                audioSource.Play();
            }
        if (scoremanager != null)
        {
            scoremanager.AddScore(pointsToAdd);;
        }
        StartCoroutine(Waitaudio());
        }

    }
    private IEnumerator Waitaudio()
    {
if (audioSource != null && audioSource.isPlaying)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            Destroy(gameObject); // Destroy the GameObject after the sound has finished playing
        }
    }
}

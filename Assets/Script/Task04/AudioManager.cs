using UnityEngine;

public class AudioManager : MonoBehaviour
{
 public AudioSource audioSource; // Reference to the AudioSource component
 public AudioClip scoresound;
 public AudioClip flapsound; // Reference to the flap sound clip 
public AudioClip crashsound;
public AudioClip backgroundmusic; // Reference to the background music clip
private static AudioManager instance; // Singleton instance of AudioManager

    private void Awake()
    {
        if (instance ==null)
        {
            instance =this;
            DontDestroyOnLoad(gameObject); // Make this object persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
 {
     audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
     PlayBackgroundMusic(); // Start playing the background music
 }

 public void PlayFlapSound()
 {
     audioSource.PlayOneShot(flapsound); // Play the flap sound effect
 }

 public void PlayScoreSound()
 {
     audioSource.PlayOneShot(scoresound); // Play the score sound effect
 }

 public void PlayCrashSound()
 {
     audioSource.PlayOneShot(crashsound); // Play the crash sound effect
 }

 private void PlayBackgroundMusic()
 {
     audioSource.clip = backgroundmusic; // Set the background music clip
     audioSource.loop = true; // Enable looping for the background music
     audioSource.Play(); // Start playing the background music

 }

public void stopbgmusic(){
audioSource.Stop();
}

}

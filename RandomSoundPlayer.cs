using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip[] audioClips; // Array to hold audio clips
    private AudioSource audioSource; // Reference to the AudioSource
    private int playCount = 0; // Count of plays to limit to 3 times

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ScheduleNextPlay();
    }

    private void ScheduleNextPlay()
    {
        if (playCount < 3) // Limit plays to 3 within 40 seconds
        {
            float delay = Random.Range(0f, 40f / 3); // Random delay within approx. 13.33s for each play
            Invoke(nameof(PlayRandomSound), delay);
        }
    }

    public void PlayRandomSound()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length); // Get a random index
            audioSource.clip = audioClips[randomIndex]; // Assign the random clip
            audioSource.Play(); // Play the sound
            playCount++; // Increment the play count
            ScheduleNextPlay(); // Schedule the next play if under the limit
        }
    }
}

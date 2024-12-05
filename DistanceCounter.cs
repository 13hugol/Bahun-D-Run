using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText; // Reference to the UI Text
    private Vector3 lastPosition; // Store the last position of the player
    private float distanceTraveled; // Total distance traveled

    void Start()
    {
        lastPosition = transform.position; // Initialize last position to the player's starting position
        distanceTraveled = 0f; // Initialize distance traveled to zero
    }

    void Update()
    {
        // Calculate the distance traveled since the last frame
        float distanceThisFrame = Vector3.Distance(transform.position, lastPosition);
        distanceTraveled += distanceThisFrame; // Update total distance traveled

        // Update the last position to the current position
        lastPosition = transform.position;

        // Update the UI text to display the distance
        distanceText.text = "Distance: " + distanceTraveled.ToString("F1"); // Display distance with 1 decimal place
    }

    // Call this when the game ends to save the distance
    public void SaveDistance()
    {
        PlayerPrefs.SetFloat("DistanceTraveled", distanceTraveled); // Save the distance in PlayerPrefs
    }
}

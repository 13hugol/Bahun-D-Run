using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAME_OVER : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinsCollected;
    [SerializeField] private TextMeshProUGUI DistanceCovered; // Reference for distance covered text

    void Start()
    {
        // Display the coins collected
        CoinsCollected.text = PlayerPrefs.GetInt("CoinsCollected").ToString();

        // Retrieve and display the distance traveled
        float distanceTraveled = PlayerPrefs.GetFloat("DistanceTraveled", 0f); // Default to 0 if not found
        DistanceCovered.text =distanceTraveled.ToString("F2"); // Display with 2 decimal places
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game"); // Reload the game scene when retry is clicked
    }
}

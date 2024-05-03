using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreScene : MonoBehaviour
{
    public TMP_Text highScoresText; // Reference to the TextMeshProUGUI object


    void Start()
    {
        // Load and display high scores
        LoadAndDisplayHighScores();
    }

    void LoadAndDisplayHighScores()
    {
        // Retrieve high scores from PlayerPrefs or another storage method
        int highScore = HighScoreManager.GetHighScore();
        Debug.Log("High Score: " + highScore);

        // Update UI to display high scores
        highScoresText.text = "High Score: " + highScore;
    }
    public void ResetHighScores()
    {
        HighScoreManager.ResetHighScore();
        // Update UI to reflect the reset high score if necessary
        LoadAndDisplayHighScores();
    }

    public void ReturnToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("wordGameStart");
    }
    public void LoadStartWordGameForTesting()
    {
        // No-op for testing purposes
    }
}
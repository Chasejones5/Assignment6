using UnityEngine;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    private static string highScoreFilePath;

    // Set the high score file path based on the platform
    private static void SetFilePath()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
    highScoreFilePath = Path.Combine(Application.persistentDataPath, "HighScores.txt");
#elif UNITY_EDITOR
    highScoreFilePath = Path.Combine(Application.dataPath, "Resources/HighScores.txt");
#else
        highScoreFilePath = Path.Combine(Application.persistentDataPath, "HighScores.txt");
#endif
    }

    public static int GetHighScore()
    {
        SetFilePath(); // Set the file path based on the platform
        if (File.Exists(highScoreFilePath))
        {
            return LoadHighScore();
        }
        else
        {
            return 0; // Return 0 if the high score file doesn't exist
        }
    }

    public static void UpdateHighScore(int newHighScore)
    {
        SetFilePath(); // Set the file path based on the platform
        SaveHighScore(newHighScore);
    }

    private static void SaveHighScore(int highScore)
    {
        try
        {
            File.WriteAllText(highScoreFilePath, highScore.ToString());
            Debug.Log($"Saved high score: {highScore}");
        }
        catch (IOException e)
        {
            Debug.LogError($"Error saving high score: {e.Message}");
        }
    }

    private static int LoadHighScore()
    {
        try
        {
            if (File.Exists(highScoreFilePath))
            {
                return int.Parse(File.ReadAllText(highScoreFilePath));
            }
            else
            {
                return 0;
            }
        }
        catch (IOException e)
        {
            Debug.LogError($"Error loading high score: {e.Message}");
            return 0;
        }
    }

    public static void ResetHighScore()
    {
        SetFilePath(); // Set the file path based on the platform
        // Reset the high score to 0
        SaveHighScore(0);
    }
}
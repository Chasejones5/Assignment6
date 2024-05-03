using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageButtons : MonoBehaviour
{
    public void StartWordGameForTesting()
    {
        // Reset the score to 0
        PlayerPrefs.SetInt("score", 0);
    }

    public void LoadStartWordGameForTesting()
    {
#if UNITY_EDITOR
        EditorSceneManager.OpenScene("Assets/Scenes/wordGameStart.unity");
#else
        SceneManager.LoadScene("wordGameStart");
#endif
    }

    public void startWordGame()
    {
        // Reset the score to 0
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("wordGame");
    }

    public void LoadStartWordGame()
    {
        SceneManager.LoadScene("wordGameStart");
    }
    public void TestReturnToMainMenuButton()
    {
#if UNITY_EDITOR
        EditorSceneManager.OpenScene("Assets/Scenes/wordGameStart.unity");
#else
        SceneManager.LoadScene("wordGameStart");
#endif
    }
    public void RestartButtonTest()
    {
#if UNITY_EDITOR
        EditorSceneManager.OpenScene("Assets/Scenes/wordGameStart.unity");
#else
        SceneManager.LoadScene("wordGameStart");
#endif
    }
    public void PlayAgainButtonTest()
    {
#if UNITY_EDITOR
        EditorSceneManager.OpenScene("Assets/Scenes/wordGameStart.unity");
#else
        SceneManager.LoadScene("wordGameStart");
#endif
    }
    public void ScoreboardButtonTest()
    {
#if UNITY_EDITOR
        EditorSceneManager.OpenScene("Assets/Scenes/wordGameScores.unity");
#else
        SceneManager.LoadScene("wordGameScores");
#endif
    }
}

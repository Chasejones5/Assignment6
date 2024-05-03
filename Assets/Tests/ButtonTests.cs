using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.TestTools.Logging;

public class ButtonTests
{
    [UnityTest]
    public IEnumerator TestStartWordGameButton()
    {
        // Create an empty GameObject
        GameObject gameObject = new GameObject();

        // Add the ManageButtons component to the GameObject
        ManageButtons manageButtons = gameObject.AddComponent<ManageButtons>();

        // Call the method to start the word game directly
        manageButtons.StartWordGameForTesting();

        // Yield null to comply with Edit Mode test requirements
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestLoadStartWordGameButton()
    {
        // Create an empty GameObject
        GameObject gameObject = new GameObject();

        // Add the ManageButtons component to the GameObject
        ManageButtons manageButtons = gameObject.AddComponent<ManageButtons>();

        // Call the method to start the word game directly
        manageButtons.StartWordGameForTesting();

        // Yield null to comply with Edit Mode test requirements
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestLoadHighScoreSceneButton()
    {
        // Create an empty GameObject
        GameObject gameObject = new GameObject();

        // Add the ManageButtons component to the GameObject
        ManageButtons manageButtons = gameObject.AddComponent<ManageButtons>();

        // Call the method to load the high score scene directly
        manageButtons.LoadStartWordGameForTesting();

        // Yield null to comply with Edit Mode test requirements
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestResetHighScoresButton()
    {
        // Call the method to reset high scores directly
        HighScoreManager.ResetHighScore();

        // Yield null to comply with Edit Mode test requirements
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestReturnToMainMenuButton()
    {
        // Create an empty GameObject
        GameObject gameObject = new GameObject();

        // Add the HighScore component to the GameObject
        HighScoreScene HighScore = gameObject.AddComponent<HighScoreScene>();

        // Call the method to load the start scene directly
        HighScore.LoadStartWordGameForTesting();

        // Yield null to comply with Edit Mode test requirements
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestQuitButton()
    {
        // Create an empty GameObject
        GameObject gameObject = new GameObject();

        // Create an instance of the GameManager class
        GameManager gameManager = gameObject.AddComponent<GameManager>();

        // Call the QuitGame method directly
        gameManager.QuitGameTest();

        // Yield null to comply with Edit Mode test requirements
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestRestartButton()
    {
        // Create an empty GameObject
        GameObject gameObject = new GameObject();

        // Create an instance of the ManageButtons class
        ManageButtons manageButtons = gameObject.AddComponent<ManageButtons>();

        // Call the RestartButtonTest method directly
        manageButtons.RestartButtonTest();

        // Yield null to comply with Edit Mode test requirements
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestPlayAgainButton()
    {
        // Create an empty GameObject
        GameObject gameObject = new GameObject();

        // Create an instance of the ManageButtons class
        ManageButtons manageButtons = gameObject.AddComponent<ManageButtons>();

        // Call the RestartButtonTest method directly
        manageButtons.PlayAgainButtonTest();

        // Yield null to comply with Edit Mode test requirements
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestScoreboardButton()
    {
        // Create an empty GameObject
        GameObject gameObject = new GameObject();

        // Create an instance of the ManageButtons class
        ManageButtons manageButtons = gameObject.AddComponent<ManageButtons>();

        // Call the RestartButtonTest method directly
        manageButtons.ScoreboardButtonTest();

        // Yield null to comply with Edit Mode test requirements
        yield return null;
    }

}
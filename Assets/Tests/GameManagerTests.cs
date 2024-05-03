using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class GameManagerTests
{
    private GameObject gameManagerObject;
    private GameManager gameManager;

    [SetUp]
    public void SetUp()
    {
        // Create a new instance of GameManager for testing
        gameManagerObject = new GameObject();
        gameManager = gameManagerObject.AddComponent<GameManager>();
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up any resources or reset values after each test
        GameObject.DestroyImmediate(gameManagerObject);
    }

    [Test]
    public void InitGame_SetWordToGuess_WordIsValid()
    {
        // Arrange
        // No arrangement needed for this test

        // Act
        gameManager.InitGame();

        // Assert
        Assert.IsTrue(gameManager.wordToGuess.Length > 0, "Word to guess is not set correctly.");
    }

    // Add more test methods here for different functionalities of the GameManager
}

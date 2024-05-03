using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class ManageButtonsTests
{
    private GameObject gameObject;
    private ManageButtons manageButtons;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        manageButtons = gameObject.AddComponent<ManageButtons>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(gameObject);
    }

    [Test]
    public void StartWordGameForTesting_SetsScoreToZero()
    {
        // Arrange
        PlayerPrefs.SetInt("score", 10);

        // Act
        manageButtons.StartWordGameForTesting();

        // Assert
        Assert.AreEqual(0, PlayerPrefs.GetInt("score"));
    }

    [Test]
    public void StartWordGameForTesting_DoesNotThrowException()
    {
        // Act & Assert
        Assert.DoesNotThrow(() => manageButtons.StartWordGameForTesting());
    }

    [Test]
    public void LoadStartWordGameForTesting_DoesNotThrowException()
    {
        // Act & Assert
        Assert.DoesNotThrow(() => manageButtons.LoadStartWordGameForTesting());
    }
}
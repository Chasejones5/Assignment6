using UnityEngine;
using NUnit.Framework;

public class HighScoreManagerTest
{
    [Test]
    public void HighScoreIsRecorded()
    {
        // Set up initial conditions
        int initialHighScore = HighScoreManager.GetHighScore();

        // Simulate a new high score
        int newHighScore = initialHighScore + 100;
        HighScoreManager.UpdateHighScore(newHighScore);

        // Check if the high score was properly recorded
        int updatedHighScore = HighScoreManager.GetHighScore();
        Assert.AreEqual(newHighScore, updatedHighScore, "High score was not recorded properly.");

        // Reset the high score back to its initial value
        HighScoreManager.ResetHighScore();
    }
    [Test]
    public void HighScoreIsReset()
    {
        // Set up initial conditions
        int initialHighScore = HighScoreManager.GetHighScore();

        // Simulate a new high score
        int newHighScore = initialHighScore + 100;
        HighScoreManager.UpdateHighScore(newHighScore);

        // Reset the high score
        HighScoreManager.ResetHighScore();

        // Check if the high score is reset to zero
        int resetHighScore = HighScoreManager.GetHighScore();
        Assert.AreEqual(0, resetHighScore, "High score was not reset to zero.");

        // Reset the high score back to its initial value
        HighScoreManager.ResetHighScore();
    }
}
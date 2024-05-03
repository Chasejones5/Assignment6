using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using UnityEngine.TestTools;
using System.Collections.Generic;

public class ImageManagerTests
{
    private ImageManager imageManager;
    private GameObject canvasObject;

    [SetUp]
    public void SetUp()
    {
        // Create a new GameObject with a Canvas component for testing
        canvasObject = new GameObject("TestCanvas");
        canvasObject.AddComponent<Canvas>();

        // Create a new GameObject for the animalImage
        GameObject animalImageObject = new GameObject("AnimalImage");
        animalImageObject.AddComponent<Image>();

        // Create a new instance of ImageManager for testing
        imageManager = canvasObject.AddComponent<ImageManager>();

        // Assign the animalImage GameObject to the animalImage property
        imageManager.animalImage = animalImageObject.GetComponent<Image>();
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up resources
        UnityEngine.Object.DestroyImmediate(canvasObject);
    }

    [UnityTest]
    public IEnumerator DisplayAnimalImage_ValidAnimalName_SpriteAssigned()
    {
        // Arrange
        string validAnimalName = "whale"; // Replace with a valid animal name from your sprites
        imageManager.animalSprites.Clear(); // Clear the animalSprites dictionary before loading

        // Act
        LoadSpritesSync(imageManager.animalSprites); // Load sprites synchronously
        imageManager.DisplayAnimalImage(validAnimalName);

        // Assert
        Assert.IsNotNull(imageManager.animalImage.sprite, "Animal sprite is not assigned.");
        yield return null; // Required for Edit Mode tests
    }

    private void LoadSpritesSync(Dictionary<string, Sprite> animalSprites)
    {
        // Load sprites synchronously using Resources.Load
        animalSprites.Add("whale", Resources.Load<Sprite>("Animals/whale"));
        animalSprites.Add("shark", Resources.Load<Sprite>("Animals/shark"));
        animalSprites.Add("seal", Resources.Load<Sprite>("Animals/seal"));
        animalSprites.Add("seaturtle", Resources.Load<Sprite>("Animals/seaturtle"));
        animalSprites.Add("squid", Resources.Load<Sprite>("Animals/squid"));
        animalSprites.Add("swordfish", Resources.Load<Sprite>("Animals/swordfish"));
        animalSprites.Add("plankton", Resources.Load<Sprite>("Animals/plankton"));
        animalSprites.Add("dolphin", Resources.Load<Sprite>("Animals/dolphin"));
        animalSprites.Add("jellyfish", Resources.Load<Sprite>("Animals/jellyfish"));
        animalSprites.Add("octopus", Resources.Load<Sprite>("Animals/octopus"));
    }

    [Test]
    public void DisplayAnimalImage_InvalidAnimalName_SpriteNotAssigned()
    {
        // Arrange
        string invalidAnimalName = "invalidanimal";

        // Act
        imageManager.DisplayAnimalImage(invalidAnimalName);

        // Assert
        Assert.IsNull(imageManager.animalImage.sprite, "Animal sprite should not be assigned.");
    }

    [Test]
    public void HideAnimalImage_ImageDeactivated()
    {
        // Arrange
        string validAnimalName = "whale"; // Replace with a valid animal name from your sprites
        imageManager.DisplayAnimalImage(validAnimalName);

        // Act
        imageManager.HideAnimalImage();

        // Assert
        Assert.IsFalse(imageManager.animalImage.gameObject.activeSelf, "Animal image should be deactivated.");
    }
}

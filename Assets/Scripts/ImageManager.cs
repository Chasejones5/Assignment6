using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public Image animalImage;
    public Dictionary<string, Sprite> animalSprites = new Dictionary<string, Sprite>();

    void Start()
    {
        StartCoroutine(LoadAnimalSprites());
    }

    public IEnumerator LoadAnimalSprites()
    {
        ResourceRequest[] requests = new ResourceRequest[]
        {
            Resources.LoadAsync<Sprite>("Animals/whale"),
            Resources.LoadAsync<Sprite>("Animals/shark"),
            Resources.LoadAsync<Sprite>("Animals/seal"),
            Resources.LoadAsync<Sprite>("Animals/seaturtle"),
            Resources.LoadAsync<Sprite>("Animals/squid"),
            Resources.LoadAsync<Sprite>("Animals/swordfish"),
            Resources.LoadAsync<Sprite>("Animals/plankton"),
            Resources.LoadAsync<Sprite>("Animals/dolphin"),
            Resources.LoadAsync<Sprite>("Animals/jellyfish"),
            Resources.LoadAsync<Sprite>("Animals/octopus")
        };

        // Wait for all requests to complete
        foreach (ResourceRequest request in requests)
        {
            yield return request;
        }

        // Assign loaded sprites to the dictionary
        foreach (ResourceRequest request in requests)
        {
            Sprite sprite = (Sprite)request.asset;
            if (sprite != null)
            {
                animalSprites.Add(sprite.name, sprite);
                Debug.Log("Loaded sprite: " + sprite.name);
            }
            else
            {
                Debug.LogError("Failed to load sprite: " + request.asset.name);
            }
        }
    }

    public void DisplayAnimalImage(string animalName)
    {
        if (animalSprites.ContainsKey(animalName))
        {
            animalImage.sprite = animalSprites[animalName];
            animalImage.gameObject.SetActive(true);

            Canvas animalImageCanvas = animalImage.GetComponentInParent<Canvas>();
            if (animalImageCanvas != null)
            {
                animalImageCanvas.sortingOrder = 10; // Adjust this value as needed
            }

            // Find the Canvas component of the guessed word text
            GameObject guessedWordTextObject = GameObject.Find("GuessedWordText");
            if (guessedWordTextObject != null)
            {
                Canvas guessedWordCanvas = guessedWordTextObject.GetComponentInParent<Canvas>();
                if (guessedWordCanvas != null)
                {
                    guessedWordCanvas.sortingOrder = 5; // Adjust this value as needed, but make it lower than the animal image's Canvas
                }
            }
        }
    }

    public void HideAnimalImage()
    {
        animalImage.gameObject.SetActive(false);
    }
}
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif


public class GameManager : MonoBehaviour
{
    public GameObject letter;
    public GameObject cen;
    public TMP_Text funFactText;
    public GameObject nextRoundButton;
    public GameObject quitGameButton;
    private string[] wordsToGuess = { "whale", "shark", "octopus", "dolphin", "seal", "swordfish", "seaturtle", "squid", "jellyfish", "plankton" };
    public string wordToGuess = "";
    private int lengthOfWordToGuess;
    char[] lettersToGuess;
    bool[] lettersGuessed;
    private int nbAttempts, maxNbAttempts;
    public TMP_Text remainingAttemptsText;
    int score = 0;
    public ImageManager imageManager;

    Dictionary<string, string> funFacts = new Dictionary<string, string>
    {
        {"whale", "Whales are the largest animals on Earth."},
        {"shark", "Sharks have been around for more than 400 million years."},
        {"octopus", "Octopi have three hearts."},
        {"dolphin", "Dolphins are known for their intelligence and playful behavior."},
        {"seal", "Seals can stay underwater for up to two hours."},
        {"swordfish", "Swordfish are known for their long, flat bill-like snout."},
        {"seaturtle", "Sea turtles can live for more than 100 years."},
        {"squid", "Squids have the largest eyes of any animal."},
        {"jellyfish", "Jellyfish have no brain, blood, or heart."},
        {"plankton", "Plankton are the foundation of the marine food web."}
    };

    // Start is called before the first frame update
    void Start()
    {
        imageManager.HideAnimalImage();
        cen = GameObject.Find("centerOfScreen");
        InitGame();
        Debug.Log("GameManager.Start() - InitGame() called successfully");
        InitLetters();
        Debug.Log("GameManager.Start() - InitLetters() called successfully");
        nbAttempts = 0;
        maxNbAttempts = 10;
        updateNbAttempts();
        updateScore();
        nextRoundButton.SetActive(false);
        quitGameButton.SetActive(true);
        LoadHighScores();
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        

    }

    // Update is called once per frame
    void Update()
    {
        //CheckKeyboard();
        checkKeyboard2();
    }
    void InitLetters()
    {
        Debug.Log("GameManager.InitLetters() - Start");

        int nbLetters = lengthOfWordToGuess;

        GameObject[] existingLetters = GameObject.FindGameObjectsWithTag("Letter");
        Debug.Log("GameManager.InitLetters() - Number of existing letters: " + existingLetters.Length);
        foreach (GameObject letter in existingLetters)
        {
            Destroy(letter);
        }

        for (int i = 0; i < nbLetters; i++)
        {
            Vector3 newPosition;
            newPosition = new Vector3(cen.transform.position.x + ((i - nbLetters / 2.0f) * 100), cen.transform.position.y, cen.transform.position.z);
            GameObject l = (GameObject)Instantiate(letter, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.tag = "Letter";
            l.transform.SetParent(GameObject.Find("Canvas").transform);
        }
        Debug.Log("GameManager.InitLetters() - End");
    }

    public void InitGame()
    {
        // Load the current score from PlayerPrefs
        score = PlayerPrefs.GetInt("score", 0);

        int randomNumber = Random.Range(0, wordsToGuess.Length);
        wordToGuess = wordsToGuess[randomNumber];
        lengthOfWordToGuess = wordToGuess.Length;
        wordToGuess = wordToGuess.ToUpper();
        maxNbAttempts = wordsToGuess.Length * 2;
        lettersToGuess = new char[lengthOfWordToGuess];
        lettersGuessed = new bool[lengthOfWordToGuess];
        lettersToGuess = wordToGuess.ToCharArray();
    }

    
    void checkKeyboard2()
    {
        if (Input.anyKeyDown)
        {
            char letterPressed = Input.inputString.ToCharArray()[0];
            int letterPressedAsInt = System.Convert.ToInt32(letterPressed);

            if (letterPressedAsInt >= 97 && letterPressed <= 122)
            {
                nbAttempts++;
                updateNbAttempts();

                if (nbAttempts > maxNbAttempts)
                {
                    SceneManager.LoadScene("wordGameEnd");
                }

                bool letterFound = false;
                for (int i = 0; i < lengthOfWordToGuess; i++)
                {
                    if (!lettersGuessed[i])
                    {
                        letterPressed = System.Char.ToUpper(letterPressed);

                        if (lettersToGuess[i] == letterPressed)
                        {
                            lettersGuessed[i] = true;
                            GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = letterPressed.ToString();
                            letterFound = true;
                        }
                    }
                }

                if (letterFound)
                {
                    score = PlayerPrefs.GetInt("score");
                    score++;
                    PlayerPrefs.SetInt("score", score);
                    updateScore();

                    // Check if the current score is higher than the high score
                    int highScore = HighScoreManager.GetHighScore();
                    if (score > highScore)
                    {
                        // If so, update the high score
                        HighScoreManager.UpdateHighScore(score);
                        Debug.Log("New High Score: " + score);
                    }
                }
            }
        }

        UpdateButtonVisibility(); // Move this line outside the loop
    }

    public void NextRound()
    {
        InitGame();
        InitLetters();
        nextRoundButton.SetActive(false);
        funFactText.text = "";
        nbAttempts = 0;
        updateNbAttempts();
        UpdateButtonVisibility();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("wordGameFinish");
    }
    void updateNbAttempts()
    {
        GameObject.Find("nbAttempts").GetComponent<TextMeshProUGUI>().text = nbAttempts + "/" + maxNbAttempts;
    }

    void updateScore()
    {
        GameObject.Find("scoreUI").GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }
    void LoadHighScores()
    {
        int highScore = HighScoreManager.GetHighScore();
        UpdateHighScoreUI(highScore);
    }

    void UpdateHighScoreUI(int highScore)
    {
        TMP_Text highScoreText = GameObject.Find("HighScoreText").GetComponent<TMP_Text>();
        highScoreText.text = "High Score: " + highScore;
    }
    public void UpdateScore(int amount)
    {
        // Update current score
        score = PlayerPrefs.GetInt("score", 0);
        score += amount;
        PlayerPrefs.SetInt("score", score);

        // Update the UI to display the current score
        updateScore();

        // Check if the current score is higher than the high score
        int highScore = HighScoreManager.GetHighScore();
        if (score > highScore)
        {
            // If so, update the high score
            HighScoreManager.UpdateHighScore(score);
            Debug.Log("New High Score: " + score);
        }
    }
    public void ShowHighScoreScene()
    {
        // Load the high score scene
        SceneManager.LoadScene("wordGameScores");
    }
    public void UpdateButtonVisibility()
    {
        if (nextRoundButton != null)
        {
            nextRoundButton.SetActive(true);
        }
        bool wordGuessed = true;
        for (int i = 0; i < lengthOfWordToGuess; i++)
        {
            if (!lettersGuessed[i])
            {
                wordGuessed = false;
                break;
            }
        }

        if (wordGuessed)
        {
            
            if (funFacts.ContainsKey(wordToGuess.ToLower()))
            {
                if (funFactText != null)
                {
                    funFactText.text = "Fun Fact: " + funFacts[wordToGuess.ToLower()];
                }
                
            }
            else
            {
                if (funFactText != null)
                {
                    funFactText.text = "No fun fact available for this word.";
                }
                
            }
            if (funFactText != null)
            {
                imageManager.DisplayAnimalImage(wordToGuess.ToLower());
                nextRoundButton.SetActive(true);
            }
            
        }
        else
        {
            imageManager.HideAnimalImage();
            nextRoundButton.SetActive(false);
        }
    }
    public void QuitGameTest()
    {
#if UNITY_EDITOR
        EditorSceneManager.OpenScene("Assets/Scenes/wordGameFinish.unity");
#else
        SceneManager.LoadScene("wordGameFinish");
#endif
    }

}
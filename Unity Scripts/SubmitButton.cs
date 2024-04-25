using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text.RegularExpressions;
public class SubmitButton : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TextMeshProUGUI scoreDisplay;
    private HighScoreManager highScoreManager;
    private GameSession gameSession;  // Add a reference to the GameSession script



    void Start()
    {
        // Find and set references to username input field, score display text, and HighScoreManager script

        highScoreManager = GameObject.FindObjectOfType<HighScoreManager>();
        gameSession = GameObject.FindObjectOfType<GameSession>();
    }

    // Attach this method to the onClick event of the submit button in the Unity editor
    public void OnSubmitButtonClick()
    {
        if (usernameInput != null && gameSession != null)
        {
            string username = usernameInput.text;
            int score = gameSession.Score;  // Get the score from the GameSession script
            Debug.Log("Username: " + username);
            Debug.Log("Score: " + score);
            highScoreManager.SubmitScore(username, score);
        }
        else
        {
            Debug.Log("Username input field or score display text is null");
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    //Variables
    [SerializeField] public int Score;
    [SerializeField] public TextMeshProUGUI ScoreText; 

    //Allows the Game Session manager to pass from one scene to another without being Destroyed
    private void Awake()
    {
        int numGameControllers = FindObjectsOfType<GameSession>().Length;
        if (numGameControllers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    //Sets the score display on scene start
    void Start(){
        UpdateScoreDisplay();
    }
    //Increases the Score when the player passes through a Pillar
    public void AddScore(){
        Score ++;
        UpdateScoreDisplay();
    }
    //Updates the score displayed on the screen
    private void UpdateScoreDisplay()
    {
        if(ScoreText != null)
        {
            ScoreText.text = "Score: " + Score.ToString();
        }
        else
        {
            Debug.LogError("ScoreText is Null");
        }
    }
   
}

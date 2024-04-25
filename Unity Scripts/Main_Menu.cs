using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //sends the user to the main game when the button is pressed
    public void PlayGame()
    {
        SceneManager.LoadScene("FlappyGreece");
    }

    //sends the user to the high score url when the button is pressed
    public void HighScore()
    {
        Application.OpenURL("http://localhost:3000/");
    }
}

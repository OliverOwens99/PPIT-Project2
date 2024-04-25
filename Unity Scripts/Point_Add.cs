using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class Point_Add : MonoBehaviour
{
    //variables
    public GameSession gameSessionManager;

    void Start()
    {
        //finds the game session manager
        gameSessionManager = FindObjectOfType<GameSession>();
    }
    //Grants the player a point when they pass through a Pillar
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == ("Player 1"))
        {
            gameSessionManager.AddScore();
        }
    }
}

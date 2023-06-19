using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager obj;
    
    public int maxLifes = 3;
    
    public bool gamePaused = false;
    public int score = 0; /*This is for TImer, i put Score for a example*/
    
    private Time timer;

    private void Awake()
    {
        obj = this;
    }
    
    void Start()
    {
     gamePaused = false;
    }
    
    public void addScore(int points) //Change this for add time to Timer
    {
        score += points;
    }

    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    private void OnDestroy()
    {
        obj = null;
    }
}

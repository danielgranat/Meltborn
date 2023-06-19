using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game obj;
    
    public int maxLifes = 3;
    
    public bool gamePaused = false;
    public int score = 0;


    private void Awake()
    {
        obj = this;
    }
    
    void Start()
    {
     gamePaused = false;   
    }
    
    public void addScore(int points)
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

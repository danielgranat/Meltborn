using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] FloatVar TIME;
    [SerializeField] float startMaxTime = 60;
    public static GameManager obj;
    
    public int maxLifes = 3;
    
    public bool gamePaused = false;
    public int score = 0; /*This is for TImer, i put Score for a example*/

    private void Awake()
    {
        obj = this;
    }
    
    void Start()
    {
        gamePaused = false;
        TIME.Value = startMaxTime;
    }

    private void Update()
    {
        if (TIME.Value <= 0)
        {
            //We probably want some kind of "Game Over" screen here.
            SceneManager.LoadScene(0);
        }
    }

    public void addScore(int points, float seconds) //Change this for add time to Timer
    {
        score += points;
        TIME.Increment(seconds);
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

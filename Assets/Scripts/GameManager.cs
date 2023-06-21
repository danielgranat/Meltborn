using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] FloatVar TIME;
    [SerializeField] FloatVar CUBES;
    [SerializeField] float startMaxTime = 60;
    [SerializeField] int cubeToTime = 10;
    public static GameManager obj;
    
    public int maxLifes = 3;
    
    public bool gamePaused = false;

    private void Awake()
    {
        obj = this;
    }
    
    void Start()
    {
        //Time.timeScale = 0.2f;
        gamePaused = false;
        TIME.Value = startMaxTime;
        CUBES.Value = 0;
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
        CUBES.Increment(points);
    }

    public void convertCubesToTime(float cubes) //Change this for add time to Timer
    {
        if (CUBES.Value < cubes) cubes = CUBES.Value;

        CUBES.Decrement(cubes);
        TIME.Increment(cubes * cubeToTime);
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

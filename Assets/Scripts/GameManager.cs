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
    [SerializeField] private float initialCubes = 0;
    [SerializeField] private int enemyInflictedDemage;
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
        CUBES.Value = initialCubes;
    }

    private void Update()
    {
        if (TIME.Value <= 0)
        {
            //We probably want some kind of "Game Over" screen here.
            gameOver();
        }
    }

    public void addScore(int points) //Change this for add time to Timer
    {
        CUBES.Increment(points);
    }

    public void enemyDemage() //Change this for add time to Timer
    {
        CUBES.Decrement(enemyInflictedDemage);
        if(CUBES.Value < 0)
        {
            gameOver();
        }
    }

    public void convertCubesToTime(float cubes) //Change this for add time to Timer
    {
        if (CUBES.Value < cubes) cubes = CUBES.Value;

        CUBES.Decrement(cubes);
        TIME.Increment(cubes * cubeToTime);
    }

    public void gameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void gameWin()
    {
        SceneManager.LoadScene(3);
    }


    private void OnDestroy()
    {
        obj = null;
    }
}

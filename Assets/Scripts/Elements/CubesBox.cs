using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesBox : MonoBehaviour
{
    private bool playerPresent = false;

    void Update()
    {
        string input = Input.inputString;
        if (playerPresent && input != "")
        {
            int number;
            if(Int32.TryParse(input,out number))
                GameManager.obj.convertCubesToTime(number);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerPresent = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerPresent = false;
    }
}

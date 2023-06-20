using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public GameObject pop;
    
    public static FXManager obj;
    
    public void Awake()
    {
        obj = this;
    }
    
    public void showPop(Vector3 pos)
    {
        pop.gameObject.GetComponent<Pop>().show(pos); //con esta linea se llama al metodo show de la clase Pop
    }

    private void OnDestroy()
    {
        obj = null;
    }
}

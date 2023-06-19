using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    [SerializeField] FloatVar TIME;
    
    public void OnAddSec(int seconds)
    {
        TIME.Increment(seconds);
    }
}

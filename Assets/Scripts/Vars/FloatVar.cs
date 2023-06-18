using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVar : ScriptableObject
{
    private float value;

    public float Value
    {
        get => value;
        set => this.value = value;
    }
    

    public void Increment(float incrementBy)
    {
        value += incrementBy;
    }

    public void Decrement(float decrementBy)
    {
        value -= decrementBy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public float Health
    {
        set => slider.value = value;
    }
}

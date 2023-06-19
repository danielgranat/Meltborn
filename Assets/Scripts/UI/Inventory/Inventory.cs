using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    FloatVar CUBES;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int cubes = (int)CUBES.Value;
        text.text = cubes.ToString("D2");
    }
}

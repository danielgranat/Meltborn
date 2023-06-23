using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CastleMelting : MonoBehaviour
{
    [SerializeField]
    FloatVar TIMER;
    private Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TIMER.Value <= 50)
        {
            float alpha = (1-(TIMER.Value / (float)50))*0.7f;
            tilemap.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        }
        else
        {
            if(tilemap.color.a > 0)
                tilemap.color = new Color(1.0f, 1.0f, 1.0f, 0f);
        }
    }
}

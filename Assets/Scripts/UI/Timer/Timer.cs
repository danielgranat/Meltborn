using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] FloatVar TIME; 
    [SerializeField] TextMeshProUGUI minText;
    [SerializeField] TextMeshProUGUI secText;
    
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.obj;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{TIME.Value}, {Time.realtimeSinceStartup} - {timeFromStart} = {Time.realtimeSinceStartup - timeFromStart}");
        TIME.Decrement(Time.deltaTime);

        int min = (int)TIME.Value / 60;
        int sec = (int)TIME.Value % 60;
        minText.text = min.ToString();
        secText.text = sec.ToString();
    }
}

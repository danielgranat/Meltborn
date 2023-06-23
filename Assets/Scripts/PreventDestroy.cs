using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventDestroy : MonoBehaviour
{

    private void Awake()
    {
        GameObject[] AmbienceBed = GameObject.FindGameObjectsWithTag("AudioSave");
        if(AmbienceBed.Length > 1)
        {
            Destroy(this.gameObject);

        }
        DontDestroyOnLoad(this.gameObject);
    }
}

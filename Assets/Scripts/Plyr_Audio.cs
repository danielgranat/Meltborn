using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyr_Audio : MonoBehaviour
{
    public AudioSource plyrAudio;
    public AudioClip[] attackAud;
    public AudioClip[] plyrFstep;
    public AudioClip[] plyrJump;
    
    // Start is called before the first frame update
    void Start()
    {

        plyrAudio = GetComponent<AudioSource>();
        

    }

  

    public void AttackAudio()
    {
        plyrAudio.clip = attackAud[Random.Range(0, attackAud.Length)];
        plyrAudio.PlayOneShot(plyrAudio.clip);
    }

    public void PlyrFootstep()
    {
        plyrAudio.clip = plyrFstep[Random.Range(0, plyrFstep.Length)];
        plyrAudio.PlayOneShot(plyrAudio.clip);
    }
    public void PlyrJump()
    {
        plyrAudio.clip = plyrJump[Random.Range(0, plyrJump.Length)];
        plyrAudio.PlayOneShot(plyrAudio.clip);
    }
}

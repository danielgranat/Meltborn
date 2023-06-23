using UnityEngine;

public class Diamond : MonoBehaviour
{
    public float timeGiven = 10f;
    public AudioSource cubeAudio;
    public AudioClip[] CubeBreak;

    public void start()
    {
        cubeAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.obj.addScore(1);
            
            //FXManager.obj.showPop(transform.position);
            Destroy(gameObject);
            cubeAudio.clip = CubeBreak[Random.Range(0, CubeBreak.Length)];
            cubeAudio.PlayOneShot(cubeAudio.clip);

        }
    }
}

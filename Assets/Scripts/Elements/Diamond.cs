using UnityEngine;

public class Diamond : MonoBehaviour
{
    public float timeGiven = 10f;
    
    public void start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.obj.addScore(1);
            
            FXManager.obj.showPop(transform.position);
            gameObject.SetActive(false);
        }
    }
}

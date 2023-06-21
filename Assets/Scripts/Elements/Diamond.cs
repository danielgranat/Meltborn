using UnityEngine;

public class Diamond : MonoBehaviour
{
    public float timeGiven = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.obj.addScore(1, timeGiven);
            
            //FXManager.obj.showPop(transform.position);
            Destroy(gameObject);
        }
    }
}

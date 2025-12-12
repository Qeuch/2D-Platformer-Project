using Unity.Cinemachine;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

            if(health.health <= 75)
            {
                health.health += 25;
                
            }
            else
            {
                health.health = 100;
            }

            health.UpdateHealthBar();

            Destroy(gameObject);
        }
    }
}

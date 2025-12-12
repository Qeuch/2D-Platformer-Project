using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Starting health value for the Player
    public int health = 100;
    public Image healthImage;
    public bool godMode = false;

    // Amount of damage the Player takes when hit
    public int damageAmount = 25;

    // Reference to the Player's SpriteRenderer (used for flashing red)
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        // Get the SpriteRenderer component attached to the Player
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHealthBar();
    }

    // Method to reduce health when damage is taken
    public void TakeDamage()
    {
        if (!godMode)
        {
            health -= damageAmount; // subtract damage amount
            UpdateHealthBar();
            StartCoroutine(BlinkRed()); // briefly flash red

            SoundManager.Instance.PlaySFX("HURT");
        }
        // If health reaches zero or below, call Die()
        if (health <= 0)
        {
            Die();
        }
    }

    // Coroutine to flash the Player red for 0.1 seconds
    private System.Collections.IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private void UpdateHealthBar()
    {
        if (healthImage != null)
        {
            healthImage.fillAmount = health / 100f;
        }
    }

    // Reload the scene when the Player dies
    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}

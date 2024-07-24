using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject gameOverUI;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void AddHealth(float amount)
    {
        health += amount;
        // Asegúrate de no exceder la salud máxima si tienes una
        // health = Mathf.Min(health, maxHealth);
    }

    void Die()
    {
        // Mostrar la pantalla de Game Over
        gameOverUI.SetActive(true);
        // Detener el tiempo
        Time.timeScale = 0f;
    }
}

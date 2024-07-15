using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Die()
    {
        // Mostrar la pantalla de Game Over
        gameOverUI.SetActive(true);
        // Detener el tiempo
        Time.timeScale = 0f;
    }
}

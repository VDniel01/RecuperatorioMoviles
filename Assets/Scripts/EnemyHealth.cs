using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
        Vibration.Vibrate(100); // Vibrar por 100 milisegundos cuando el enemigo recibe daño
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
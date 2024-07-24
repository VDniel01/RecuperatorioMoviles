using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield playerShield = other.GetComponent<PlayerShield>();
            if (playerShield != null)
            {
                playerShield.ActivateShield(shieldDuration);
                Destroy(gameObject); // Destruir el power-up después de recogerlo
            }
        }
    }
}

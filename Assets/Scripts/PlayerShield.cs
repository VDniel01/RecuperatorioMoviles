using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShield : MonoBehaviour
{
    public Image shieldUI; // Imagen de la UI para el escudo
    private bool isShieldActive = false;
    private float shieldEndTime = 0f;

    void Update()
    {
        if (isShieldActive && Time.time > shieldEndTime)
        {
            DeactivateShield();
        }

        // Opcional: Actualiza la visualización del escudo en la UI
        if (shieldUI != null)
        {
            shieldUI.fillAmount = Mathf.Clamp01((shieldEndTime - Time.time) / shieldEndTime);
        }
    }

    public void ActivateShield(float duration)
    {
        isShieldActive = true;
        shieldEndTime = Time.time + duration;
        // Activar la visualización del escudo
        if (shieldUI != null)
        {
            shieldUI.gameObject.SetActive(true);
        }
    }

    void DeactivateShield()
    {
        isShieldActive = false;
        // Desactivar la visualización del escudo
        if (shieldUI != null)
        {
            shieldUI.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isShieldActive && other.CompareTag("EnemyProjectile"))
        {
            // Destruir el proyectil
            Destroy(other.gameObject);
        }
    }
}

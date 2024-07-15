using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Text healthText;
    public PlayerHealth playerHealth;

    void Update()
    {
        healthText.text = " " + playerHealth.health.ToString();
    }
}

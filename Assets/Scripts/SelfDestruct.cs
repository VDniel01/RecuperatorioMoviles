using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifetime = 2f; // Duraci�n del efecto antes de destruirse

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}

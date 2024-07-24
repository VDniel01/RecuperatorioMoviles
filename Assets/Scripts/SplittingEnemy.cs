using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SplittingEnemy : MonoBehaviour
{
    public GameObject smallEnemyPrefab; // Prefab para SmallEnemy
    public float startingHealth = 200f; // Vida alta
    public float speed = 2f; // Movimiento lento
    public float damage = 25f; // Daño alto
    private float currentHealth;
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        currentHealth = startingHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Split();
            Destroy(gameObject);
        }
    }

    void Split()
    {
        // Crear dos instancias de SmallEnemy cerca de la posición del SplittingEnemy
        Vector3 offset1 = new Vector3(1f, 0, 0); // Posición a la derecha
        Vector3 offset2 = new Vector3(-1f, 0, 0); // Posición a la izquierda

        Instantiate(smallEnemyPrefab, transform.position + offset1, Quaternion.identity);
        Instantiate(smallEnemyPrefab, transform.position + offset2, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
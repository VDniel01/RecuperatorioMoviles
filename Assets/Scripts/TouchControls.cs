using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    private Vector2 moveDirection;

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        foreach (Touch touch in Input.touches)
        {
            // Verificar si el toque está en la mitad izquierda de la pantalla
            if (touch.position.x < Screen.width / 2)
            {
                HandleMovement(touch);
            }
            // Verificar si el toque está en la mitad derecha de la pantalla
            else if (touch.phase == TouchPhase.Began)
            {
                HandleShooting(touch);
            }
        }
    }

    void HandleMovement(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                // Almacenar la posición inicial del toque
                break;

            case TouchPhase.Moved:
                // Calcular la dirección de movimiento
                Vector2 touchDelta = touch.deltaPosition;
                moveDirection = new Vector2(touchDelta.x, touchDelta.y).normalized;
                transform.Translate(new Vector3(moveDirection.x, 0, moveDirection.y) * moveSpeed * Time.deltaTime);
                break;

            case TouchPhase.Ended:
                // Resetear la dirección de movimiento
                moveDirection = Vector2.zero;
                break;
        }
    }

    void HandleShooting(Touch touch)
    {
        Vector3 shootDirection = FindClosestEnemyDirection();
        if (shootDirection != Vector3.zero)
        {
            Shoot(shootDirection);
        }
    }

    Vector3 FindClosestEnemyDirection()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(firePoint.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            return (closestEnemy.transform.position - firePoint.position).normalized;
        }

        return Vector3.zero;
    }

    void Shoot(Vector3 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = direction * projectileSpeed;

        // Añadir vibración al disparar
        Vibration.Vibrate(50); // Vibrar por 50 milisegundos
    }
}

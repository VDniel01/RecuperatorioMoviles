using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 touchStart;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = touch.position;
                    break;
                case TouchPhase.Moved:
                    Vector2 direction = touch.position - touchStart;
                    transform.Translate(new Vector3(direction.x, 0, direction.y).normalized * moveSpeed * Time.deltaTime);
                    break;
            }
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            // Implementar lógica para disparar en la dirección del toque
        }
    }
}
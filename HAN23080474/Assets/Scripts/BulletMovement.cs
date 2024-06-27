using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private void Awake()
    {
        if (!rb)
        {
            renderer = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
        }
    }

    public void Launch(float velX, float velY)
    {
        rb.velocity = new Vector2(speed * velX, speed * velY);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy") || collider.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public static float velX;
    public static float velY;

    private static Rigidbody2D rb;

    private bool isDestroyed = false;


    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        AddRigidbody();
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        AddRigidbody();
        if (!isDestroyed)
        {
            Movement();
        }


    }

    void Movement()
    {
        AddRigidbody();
        if (!isDestroyed)
        {
            rb.velocity = new Vector2(velX, velY);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isDestroyed) return; // Skip if already marked for destruction

        if (collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collide with enemy");
            // Mark the bullet as destroyed
            isDestroyed = true;

            Destroy(collider.gameObject);

            Destroy(gameObject);
            //Destroy(collider,1.0f);
            Debug.Log("Has not destroyed");
            Destroy(this);
        }
    }

    private void AddRigidbody()
    {
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0; // Ensure the bullet is not affected by gravity
            rb.freezeRotation = true; // Freeze the rotation
            rb.angularDrag = 0; // Set angular drag to 0
        }
    }
}
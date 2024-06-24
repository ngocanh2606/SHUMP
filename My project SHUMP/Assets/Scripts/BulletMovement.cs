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
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed)
        {
            // Prevent any updates if the bullet is destroyed
            return;
        }
        Movement();
        
        

    }

    void Movement()
    {
        if (isDestroyed)
        {
            // Prevent any updates if the bullet is destroyed
            return;
        }
        rb.velocity = new Vector2(velX, velY);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isDestroyed) return; // Skip if already marked for destruction

        if (collider.CompareTag("Enemy"))
        {
            // Mark the bullet as destroyed
            isDestroyed = true;

            Destroy(collider.gameObject);

            Destroy(gameObject);
            //Destroy(collider,1.0f);
            Debug.Log("Has not destroyed");
        }
    }
}
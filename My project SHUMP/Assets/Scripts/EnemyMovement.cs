using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed;

    private Vector2 movementDirection;
    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //anim = GetComponent<Animator>();
        UpdateMovementDirection();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            MoveEnemy();
        }
    }

    void MoveEnemy()
    {
        // Move the enemy in the current direction
        transform.position += new Vector3(movementDirection.x, movementDirection.y, 0) * speed * Time.deltaTime;
    }

    void UpdateMovementDirection()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Move only horizontally
                movementDirection = new Vector2(direction.x, 0);
            }
            else
            {
                // Move only vertically
                movementDirection = new Vector2(0, direction.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            // Update direction when colliding with a boundary
            UpdateMovementDirection();
        }
    }
}
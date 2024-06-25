using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player!=null)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            // Calculate direction towards the player
            Vector2 direction = player.transform.position - transform.position;

            // Normalize the direction vector so that the enemy moves at a consistent speed
            direction.Normalize();

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Move only horizontally
                transform.position += new Vector3(direction.x, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                // Move only vertically
                transform.position += new Vector3(0, direction.y, 0) * speed * Time.deltaTime;
            }
        }
        
    }
}

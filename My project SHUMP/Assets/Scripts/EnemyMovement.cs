using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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


        //    float angle = Mathf.Atan2(direction.y, direction.x); *Mathf.Rad2Dog

        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed *Time.deltaTime);
    }
}

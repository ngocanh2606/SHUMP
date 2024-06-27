using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private GameObject deathAnim;

    private float distance;

    //public Ability[] possibleAbilities;
    //public float dropChance = 0.5f; // 50% chance to drop an ability

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            Instantiate(deathAnim, transform.position, Quaternion.identity);
            //DropAbility();
            Destroy(gameObject);
        }
    }

    //void DropAbility()
    //{
    //    if (Random.value < dropChance && possibleAbilities.Length > 0)
    //    {
    //        Ability droppedAbility = possibleAbilities[Random.Range(0, possibleAbilities.Length)];
    //        // Assuming the player is tagged "Player"
    //        GameObject player = GameObject.FindGameObjectWithTag("Player");
    //        if (player != null)
    //        {
    //            PlayerController playerController = player.GetComponent<PlayerController>();
    //            if (playerController != null)
    //            {
    //                playerController.AddAbility(droppedAbility);
    //            }
    //        }
    //    }
    //}
}
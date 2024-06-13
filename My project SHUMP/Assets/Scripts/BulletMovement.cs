using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    //[SerializeField] public static float speedX;
    //[SerializeField] public static float speedY;
    private float moveSpeed = 2;
    private Vector2 moveDirection;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        if(Input.GetAxisRaw("Horizontal2") || Input.GetAxisRaw("Vertical2"))
        {
            GameObject bullet = Instantiate(bulletPrefab, player.tranform.position, Quaternion.identity);
            Launch();
        }
    }

    void FixedUpdate()
    {
        //Launch();
        
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal2");
        float moveY = Input.GetAxisRaw("Vertical2");

        moveDirection = new Vector2(moveX, moveY);

    }

    void Launch()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
    }
}

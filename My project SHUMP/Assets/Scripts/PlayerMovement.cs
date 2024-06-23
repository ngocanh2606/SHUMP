using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float moveSpeed;

    private Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        ProcessInputs(); 
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX,moveY);

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }


    
}

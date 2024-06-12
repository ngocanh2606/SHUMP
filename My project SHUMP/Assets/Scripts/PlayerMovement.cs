using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float moveSpeed;
    //[SerializeField] public Vector2 forceToApply;
    //[SerializeField] public float forceDamping;

    private Vector2 MoveDirection;

    public GameObject playerBulletPrefab;
    [SerializeField] public Transform playerTransform;
    [SerializeField] public Transform playerBulletTransform;

    private float fireRate;
    private float rightOrUp;
    private float leftOrDown;
    private float pbx;
    private float pby;
    float nextFire;

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

        MoveDirection = new Vector2(moveX,moveY);

    }

    void Move()
    {
        rb.velocity = new Vector2(MoveDirection.x * moveSpeed, MoveDirection.y * moveSpeed);
    }

    
}

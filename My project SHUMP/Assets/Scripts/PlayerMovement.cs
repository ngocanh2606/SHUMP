using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float moveSpeed;

    private SpriteRenderer sprite;
    private Animator anim;

    private Vector2 moveDirection;
    private MovementState state;

    private enum MovementState
    {
        idle, walking
    }


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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

        moveDirection = new Vector2(moveX, moveY);

        if (moveX == 0f && moveY == 0f)
        {
            state = MovementState.idle;
        }
        else
        {
            state = MovementState.walking;
            if(moveX<0f)
            {
                sprite.flipX=true;
            }
            else if (moveX > 0f)
            {
                sprite.flipX=false;
            }
        }
        anim.SetInteger("state", (int)state);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void AdjustSpeed(float amount, float duration)
    {
        StartCoroutine(IncreaseSpeed(amount, duration));
    }

    private IEnumerator IncreaseSpeed(float amount, float duration)
    {
        moveSpeed += amount;
        Debug.Log("Move speed= "+moveSpeed);
        yield return new WaitForSeconds(duration);
        moveSpeed -= amount;
    }
    
}

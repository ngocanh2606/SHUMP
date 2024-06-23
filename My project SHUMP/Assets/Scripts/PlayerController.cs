using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public Transform playerTransform;
    public float fireRate;
    public float rightOrUp;
    public float leftOrDown;
    public float diagonalFire;

    public Rigidbody2D rb;
    public float playerX;
    public float playerY;
    public Transform playerBulletTransform;

    float pbx;
    float pby;
    float nextFire;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    //void Update()
    //{
    //	fireUpRight();
    //	fireUpLeft();
    //	fireDownRight();
    //	fireDownLeft();
    //}

    void FixedUpdate()
    {
        fireUpRight();
        fireUpLeft();
        fireDownRight();
        fireDownLeft();

    }


    void CreatePlayerBullet()
    {
        Instantiate(playerBulletPrefab, playerTransform.position, Quaternion.identity);
    }

    void fireDownLeft()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire && Input.GetKey(KeyCode.LeftArrow))
        {
            nextFire = Time.time + fireRate;
            CreatePlayerBullet();
            pbx = leftOrDown * diagonalFire;
            pby = leftOrDown * diagonalFire;
            BulletMovement.velX = pbx;
            BulletMovement.velY = pby;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            CreatePlayerBullet();
            pbx = 0;
            pby = leftOrDown;
            BulletMovement.velX = pbx;
            BulletMovement.velY = pby;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            CreatePlayerBullet();
            pbx = leftOrDown;
            pby = 0;
            BulletMovement.velX = pbx;
            BulletMovement.velY = pby;
        }
    }



    void fireUpLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire && Input.GetKey(KeyCode.UpArrow))
        {
            nextFire = Time.time + fireRate;
            CreatePlayerBullet();
            pbx = leftOrDown * diagonalFire;
            pby = rightOrUp * diagonalFire;
            BulletMovement.velX = pbx;
            BulletMovement.velY = pby;
        }

        else if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            CreatePlayerBullet();
            pbx = 0;
            pby = rightOrUp;
            BulletMovement.velX = pbx;
            BulletMovement.velY = pby;
        }
    }

    void fireDownRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire && Input.GetKey(KeyCode.DownArrow))
        {
            nextFire = Time.time + fireRate;
            CreatePlayerBullet();
            pbx = rightOrUp * diagonalFire;
            pby = leftOrDown * diagonalFire;
            BulletMovement.velX = pbx;
            BulletMovement.velY = pby;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            CreatePlayerBullet();
            pbx = rightOrUp;
            pby = 0;
            BulletMovement.velX = pbx;
            BulletMovement.velY = pby;
        }

    }

    void fireUpRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire && Input.GetKey(KeyCode.UpArrow))
        {

            nextFire = Time.time + fireRate;
            CreatePlayerBullet();
            pbx = rightOrUp * diagonalFire;
            pby = rightOrUp * diagonalFire;
            BulletMovement.velX = pbx;
            BulletMovement.velY = pby;
        }

    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {

        }
    }
}
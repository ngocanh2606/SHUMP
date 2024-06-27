using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInput : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public Transform playerTransform;
    public float fireRate;
    public float rightOrUp;
    public float leftOrDown;
    public float diagonalFire;

    private float pbx;
    private float pby;
    private float nextFire;

    void FixedUpdate()
    {
        fireUpRight();
        fireUpLeft();
        fireDownRight();
        fireDownLeft();
    }


    void CreatePlayerBullet()
    {
        GameObject go = Instantiate(playerBulletPrefab, playerTransform.position, Quaternion.identity);
        BulletMovement bullet = go.GetComponent<BulletMovement>();
        bullet.Launch(pbx, pby);
    }

    void fireDownLeft()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire && Input.GetKey(KeyCode.LeftArrow))
        {
            nextFire = Time.time + fireRate;
            pbx = leftOrDown * diagonalFire;
            pby = leftOrDown * diagonalFire;
            CreatePlayerBullet();
         
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            pbx = 0;
            pby = leftOrDown;
            CreatePlayerBullet();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            pbx = leftOrDown;
            pby = 0;
            CreatePlayerBullet();
        }
    }



    void fireUpLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire && Input.GetKey(KeyCode.UpArrow))
        {
            nextFire = Time.time + fireRate;
            pbx = leftOrDown * diagonalFire;
            pby = rightOrUp * diagonalFire;
            CreatePlayerBullet();
        }

        else if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            pbx = 0;
            pby = rightOrUp;
            CreatePlayerBullet();
        }
    }

    void fireDownRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire && Input.GetKey(KeyCode.DownArrow))
        {
            nextFire = Time.time + fireRate;
            pbx = rightOrUp * diagonalFire;
            pby = leftOrDown * diagonalFire;
            CreatePlayerBullet();
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            pbx = rightOrUp;
            pby = 0;
            CreatePlayerBullet();
        }
    }

    void fireUpRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire && Input.GetKey(KeyCode.UpArrow))
        {

            nextFire = Time.time + fireRate;
            pbx = rightOrUp * diagonalFire;
            pby = rightOrUp * diagonalFire;
            CreatePlayerBullet();
        }
    }
}
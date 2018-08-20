using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blackPlayer : MonoBehaviour
{
    
    Quaternion bulletRotation;

    public Camera cam;
    public GameObject bullet;


    BoxCollider2D boxCol;

    public LayerMask groundLayer;
    public float speed;
    Vector2 position;
    Vector2 direction;
    Rigidbody2D rb;
    bool doubleBounced = false;
    float jumpHeight = 1.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();

        // '/' to shoot
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DoShoot();
        }


    }

    //I think it's pretty obvious, but this is where we control the shooting
    private void DoShoot()
    {
        Instantiate(bullet, transform.position, bulletRotation);
    }


    private void DoMovement()
    {
        if (IsGrounded() && rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x + (0 + Math.Abs(rb.velocity.x)) * 0.1f, rb.velocity.y);
        }
        else if (IsGrounded() && rb.velocity.x > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x - (rb.velocity.x * 0.1f), rb.velocity.y);
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * jumpHeight);
        }

        //double bounce
        else if (Input.GetKeyDown(KeyCode.W) && doubleBounced == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * 1.3f);
            doubleBounced = true;
        }
        //getKey rather than getKey down so you can hold it down
        if (Input.GetKey(KeyCode.D))
        {
            //so the bullet knows they're facing right
            bulletRotation = new Quaternion(0, 0, 0, 0);
            if (IsGrounded())
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * 0.8f, rb.velocity.y);
            }

        }
        if (Input.GetKey(KeyCode.A))
        {
            //so the bullet knows they're facing left
            bulletRotation = new Quaternion(0, 0, 180, 0);
            if (IsGrounded())
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed * 0.8f, rb.velocity.y);
            }
        }

    }

    bool IsGrounded()
    {
        position = transform.position;
        direction = Vector2.down;
        float distance = 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            doubleBounced = false;
            return true;
        }
        return false;
    }


    //when they go off the screen, make them come back the other side
    void OnBecameInvisible()
    {
        //Debug.Log("invisible");
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);
        Vector3 newPos = transform.position;
        if (viewportPos.x > 0.99f)
        {
            //Debug.Log("working");
            newPos = cam.ViewportToWorldPoint(new Vector3(0.001f, viewportPos.y, viewportPos.z));
            transform.position = newPos;
        }
        else if (viewportPos.x < 0.01f)
        {
            //Debug.Log("working");
            newPos = cam.ViewportToWorldPoint(new Vector3(0.99f, viewportPos.y, viewportPos.z));
            transform.position = newPos;
        }
    }



}


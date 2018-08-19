using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhitePlayer : MonoBehaviour {

	
    BoxCollider2D boxCol;

    public LayerMask groundLayer;
    public float speed;
    Vector2 position;
    Vector2 direction;
    Rigidbody2D rb;
    bool doubleBounced = false;
    float jumpHeight = 1.0f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start() {
        position = transform.position;
    }

    // Update is called once per frame
    void Update() {
       


        if (IsGrounded() && rb.velocity.x < 0) {
            rb.velocity = new Vector2(rb.velocity.x + (0 + Math.Abs(rb.velocity.x)) * 0.1f, rb.velocity.y);
        }
        else if (IsGrounded() && rb.velocity.x > 0) {
            rb.velocity = new Vector2(rb.velocity.x - (rb.velocity.x * 0.1f), rb.velocity.y);
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow)) {
            rb.velocity = new Vector2(rb.velocity.x, speed * jumpHeight);
        }

        //double bounce
        else if (Input.GetKeyDown(KeyCode.UpArrow) && doubleBounced == false) {
            rb.velocity = new Vector2(rb.velocity.x, speed * 1.3f);
            doubleBounced = true;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            if (IsGrounded()) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else {
                rb.velocity = new Vector2(speed * 0.8f, rb.velocity.y);
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (IsGrounded()) {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else {
                rb.velocity = new Vector2(-speed * 0.8f, rb.velocity.y);
            }
        }

    }

    bool IsGrounded() {
        position = transform.position;
        direction = Vector2.down;
        float distance = 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        
        if (hit.collider != null) {
            
            doubleBounced = false;
            return true;
        }

        return false;
    }

    public void ResetVelocity() {
        rb.velocity = Vector2.zero;
    }



}


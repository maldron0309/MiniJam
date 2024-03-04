using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] float speed = 5f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        Move();
        FlipSprite();
    }

    void Move()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        Vector2 playerVelocity = new Vector2(moveInput.x * speed, rb.velocity.y);
        rb.velocity = playerVelocity;

        if (HasHorizontalSpeed())
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void FlipSprite()
    {
        if (HasHorizontalSpeed())
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    bool HasHorizontalSpeed()
    {
        return Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
    }



}

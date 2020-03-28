﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] float speed;

    [Header("References")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    float horizontal;
    float vertical;
    float movementSpeed;
    Vector2 movementDirection;
    float lastDirectionHorizontal = 0;
    float lastDirectionVertical = 0;
    void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        movementDirection = new Vector2(0, 0);
        Animate(lastDirectionHorizontal, lastDirectionVertical);
        if (horizontal > 0.5f || horizontal < -0.5f)
        {
            lastDirectionHorizontal = horizontal;
            lastDirectionVertical = 0;
            movementDirection = new Vector2(horizontal, 0);
            Animate(horizontal, 0);
        } 
        else if (vertical > 0.5f || vertical < -0.5f)
        {
            lastDirectionVertical = vertical;
            lastDirectionHorizontal = 0;
            movementDirection = new Vector2(0, vertical);
            Animate(0, vertical);
        }
        rb.velocity = movementDirection * speed;
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        float lastDir = transform.eulerAngles.y;
        Debug.Log(lastDir);
    }

    void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void Animate(float horizontal, float vertical)
    {
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);
        anim.SetFloat("Speed", movementSpeed);
    }
}

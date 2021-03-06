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
    bool enabled;
    public bool dead;
    public static PlayerMovement Instance { get { return _instance; } }
    private static PlayerMovement _instance;
    
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            enabled = true;
            _instance = this;
        }
    }

    void Update()
    {
        if(dead) return;
        if (enabled)
        {
            GetInput();
        }
    }

    private void FixedUpdate()
    {
        if(dead) return;

        if (enabled)
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
        }
    }

    void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void Animate(float horizontal, float vertical)
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            anim.SetLayerWeight(1, 1);
            anim.SetLayerWeight(0, 0);
            anim.SetBool("Walking", true);
            anim.SetFloat("Horizontal", horizontal);
            anim.SetFloat("Vertical", vertical);
        }
        else
        {
            anim.SetLayerWeight(0, 1);
            anim.SetLayerWeight(1, 0);
            anim.SetBool("Walking", false);
        }
    }

    public void SetMovementEnabled(bool state)
    {
        enabled = state;
        anim.SetLayerWeight(0, 1);
        anim.SetLayerWeight(1, 0);
        anim.SetBool("Walking", false);

        if (state) return;
        horizontal = 0;
        vertical = 0;
        movementDirection = new Vector2(0, 0);
        movementSpeed = 0;
        rb.velocity = new Vector2(0, 0);
        if (dead)
        {
            Animate(0, 0);
        }
    }
}

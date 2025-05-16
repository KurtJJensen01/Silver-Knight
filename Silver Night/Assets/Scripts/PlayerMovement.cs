using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 40f;
    public float jumpForce;
    public float heightCutter;
    public float KnockbackForce;
    public float KnockbackCounter;
    public float KnockbackTime;
    public bool KnockedFromRight;

    private readonly float radius = 0.3f;
    private Transform pos;
    private LayerMask groundLayer;
    private LayerMask platformLayer;
    private Animator animator;
    private float moveInput;
    private bool grounded = false;
    private bool platformed = false;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        platformLayer = LayerMask.GetMask("Platform");
        pos = GameObject.FindGameObjectWithTag("Feet").transform;
    }

    void Update()
    {
        if (KnockbackCounter <= 0)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            moveInput = Input.GetAxis("Horizontal");

            animator.SetFloat("Speed", Mathf.Abs(moveInput));

            if (moveInput < 0)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (moveInput > 0)
            {
                gameObject.transform.localScale = new Vector3(1, 1, -1);
            }
            grounded = Physics2D.OverlapCircle(pos.position, radius, groundLayer);
            platformed = Physics2D.OverlapCircle(pos.position, radius, platformLayer);
            if ((grounded || platformed) && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * heightCutter);
                }
            }
        }
        else
        {
            if (KnockedFromRight == true)
            {
                rb.velocity = new Vector2(-KnockbackForce, KnockbackForce/2);
            }
            else
            {
                rb.velocity = new Vector2(KnockbackForce, KnockbackForce/2);
            }
            KnockbackCounter-=Time.deltaTime;
        }
    }
}

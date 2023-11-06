using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f; // Kecepatan gerak Pemain
    [SerializeField] private float jumpForce = 5f; // Kekuatan lompatan Pemain

    [SerializeField] private LayerMask groundLayer;
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D coll;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        WalkingAnimation(dirX);

        // Walking Player
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // Alternatif Walking Player
        // Vector3 movement = new Vector3(dirX * moveSpeed * Time.deltaTime, 0f);
        // transform.Translate(movement);

        // Jumping Player
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void WalkingAnimation(float direction)
    {
        if (direction > 0)
        {
            anim.SetBool("isWalking", true);
            sprite.flipX = false;
        }
        else if (direction < 0)
        {
            anim.SetBool("isWalking", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("isWalking", false);

        }
    }

    private bool isGrounded()
    {
        // return Physics2D.OverlapCircle(groundCheck.position, -0.2f, groundLayer);
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}

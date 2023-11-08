using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f; // Kecepatan gerak Pemain
    [SerializeField] private float jumpForce = 5f; // Kekuatan lompatan Pemain

    [field: SerializeField]
    public float KBForce { get; private set; }

    [field: SerializeField]
    public float KBTotalTime { get; private set; }
    public float KBCounter { private get; set; }
    public bool isRightKB { private get; set; }

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

        if (KBCounter <= 0)
        {
            // Walking Player
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else
        {
            // Knockback Player and Disable Walking Player
            if (isRightKB == true)
            {
                rb.velocity = new(-KBForce, KBForce);
            }
            if (isRightKB == false)
            {
                rb.velocity = new(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }

        // Jumping Player
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("isJumping", true);
        }
        if (rb.velocity.y == 0f)
        {
            anim.SetBool("isJumping", false);
        }

        // Alternatif Walking Player
        // Vector3 movement = new Vector3(dirX * moveSpeed * Time.deltaTime, 0f);
        // transform.Translate(movement);
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

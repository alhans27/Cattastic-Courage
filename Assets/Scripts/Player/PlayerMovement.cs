using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private Animator anim;      // Kecepatan gerak Pemain
    private SpriteRenderer sprite;      // Kecepatan gerak Pemain

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        // float dirY = Input.GetAxisRaw("Vertical");


        WalkingAnimation(dirX);
        Vector3 movement = new Vector3(dirX * moveSpeed * Time.deltaTime, 0f);
        transform.Translate(movement);
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
}

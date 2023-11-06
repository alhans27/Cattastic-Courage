using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float knockbackForce;
    [SerializeField] private float attackForce;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.GetDamage(attackForce);

            if (playerHealth.currentHealth > 0)
            {
                Vector2 knockbackDirection = (other.gameObject.transform.position - transform.position).normalized;

                // Mendapatkan komponen Rigidbody2D pemain
                Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();

                // Menerapkan kekuatan knockback dengan mengubah posisi pemain
                playerRigidbody.position = knockbackDirection * knockbackForce;
            }

        }
    }
}

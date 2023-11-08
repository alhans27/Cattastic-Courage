using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // [SerializeField] private float knockbackForce;
    [SerializeField] private float attackForce;
    [SerializeField] private PlayerMovement playerMovement;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.GetDamage(attackForce);

            if (playerHealth.currentHealth > 0)
            {
                playerMovement.KBCounter = playerMovement.KBTotalTime;
                if (other.transform.position.x <= transform.position.x)
                {
                    playerMovement.isRightKB = true;
                }
                if (other.transform.position.x > transform.position.x)
                {
                    playerMovement.isRightKB = false;
                }
            }
            else
            {
                playerMovement.KBCounter = 0;
            }

        }
    }


    void DestroyItsSelf()
    {
        Destroy(this.gameObject);
    }
}

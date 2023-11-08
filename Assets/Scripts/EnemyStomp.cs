using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weak Point")
        {
            GameManager.Instance.SetScore(20);
            other.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Dead");
        }
    }
}

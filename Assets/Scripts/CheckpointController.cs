using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] private GameObject textCheckpoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textCheckpoint.SetActive(true);
            GameManager.Instance.SetCheckpoint(transform.position);
            GameManager.Instance.SetCPStatus(true);
            Debug.Log($"CP Status: {GameManager.Instance.GetCPStatus()}");
            Debug.Log($"Checkpoint Position: {GameManager.Instance.GetCheckpoint()}");
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

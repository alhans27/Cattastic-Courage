using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    [SerializeField] private AudioSource checkpointSound;
    [SerializeField] private GameObject textCheckpoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textCheckpoint.SetActive(true);
            checkpointSound.Play();
            GameManager.Instance.SetCheckpoint(transform.position);
            GameManager.Instance.SetCPStatus(true);
            GameManager.Instance.SetLastPH(other.GetComponent<PlayerHealth>().currentHealth);
            Debug.Log($"CP Status: {GameManager.Instance.GetCPStatus()}");
            Debug.Log($"Checkpoint Position: {GameManager.Instance.GetCheckpoint()}");
            Debug.Log($"Last Health: {other.GetComponent<PlayerHealth>().currentHealth}");
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

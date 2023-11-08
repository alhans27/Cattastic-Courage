using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    // [SerializeField] private AudioSource finishSoundEffect;

    private bool levelCompleted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !levelCompleted)
        {
            levelCompleted = true;
            // finishSoundEffect.Play();
            Invoke("NextLevel", 1.5f);
        }
    }

    private void NextLevel()
    {
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        GameManager.Instance.SetLevel(level);
        SceneManager.LoadScene(level);
    }
}
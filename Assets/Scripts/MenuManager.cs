using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private static MenuManager instance;
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    [SerializeField] private GameObject deadMenuPanel = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;

    public static MenuManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Mencari Object yang memiliki script Game Manager
                instance = FindObjectOfType<MenuManager>();

                // Jika belum ada objek yang memiliki script Game Manager
                if (instance == null)
                {
                    // Membuat objek baru
                    GameObject obj = new GameObject("MenuManager");
                    instance = obj.AddComponent<MenuManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (scoreText != null)
        {
            int score = GameManager.Instance.GetHighScore();
            scoreText.text = $"Score : {score}";
        }
    }

    public void SecondChange()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        if (GameManager.Instance.GetCPStatus())
        {
            playerMovement.transform.position = GameManager.Instance.GetCheckpoint();
            playerMovement.enabled = true;
            playerMovement.respawn = true;
            playerHealth.currentHealth = GameManager.Instance.GetLastPH();
            if (deadMenuPanel != null)
            {
                deadMenuPanel.SetActive(false);
            }
            Debug.Log(playerMovement.transform.position);
            Debug.Log(playerHealth.currentHealth);
        }
    }

    public void StartGame()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 2;
        SceneManager.LoadScene(index);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LeaderboardMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        if (deadMenuPanel != null)
        {
            deadMenuPanel.SetActive(false);
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public static MenuManager instance;
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;

    [SerializeField] private GameObject deadMenuPanel;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TMP_InputField inputName;

    private string playerName;

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
            int score = Storage.highScore;
            scoreText.text = $"Score : {score}";
        }

        if (playerNameText != null)
        {
            playerNameText.text = $"Player Name : {Storage.playerName}";
        }
    }

    void Update()
    {
        Debug.Log(Storage.highScore);
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
        if (inputName != null)
        {
            if (inputName.text != "")
            {
                Storage.playerName = inputName.text;
            }
            else
            {
                Storage.playerName = "Default Player";
            }
        }
        int index = SceneManager.GetActiveScene().buildIndex + 2;
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit From Game");
    }
    public void ContinueGame()
    {
        Debug.Log("Continue the Game");
        SceneManager.LoadScene(Storage.saveLevel);
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
        GameManager.Instance.ResetHighScore();
        GameManager.Instance.ResetScore();
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        if (deadMenuPanel != null)
        {
            deadMenuPanel.SetActive(false);
        }
    }
}

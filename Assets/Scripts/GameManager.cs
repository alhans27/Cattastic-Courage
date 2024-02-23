using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score;
    private int highScore;
    private int fishItem;
    private int foodItem;
    private int level;
    private float lastPlayerHealth;
    private bool isCheckStatus = false;
    private Vector2 lastCheckpoint;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Mencari Object yang memiliki script Game Manager
                instance = FindObjectOfType<GameManager>();

                // Jika belum ada objek yang memiliki script Game Manager
                if (instance == null)
                {
                    // Membuat objek baru
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    public int GetScore()
    {
        return score;
    }
    public void SetScore(int value)
    {
        score += value;
        if (score > highScore)
        {
            Instance.SetHighScore(score);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ResetHighScore()
    {
        highScore = 0;
    }
    public int GetHighScore()
    {
        return highScore;
    }

    public void SetHighScore(int value)
    {
        highScore = value;
    }
    public int GetFishItem()
    {
        return fishItem;
    }

    public void SetFishItem(int value)
    {
        int point = 200;
        fishItem = value;
        Instance.SetScore(point);
    }
    public int GetFoodItem()
    {
        return foodItem;
    }

    public void SetFoodItem(int value)
    {
        int point = 50;
        foodItem = value;
        Instance.SetScore(point);
    }

    public void SetLevel(int index)
    {
        level = index;
    }

    public int GetLevel()
    {
        return level;
    }
    public void SetCheckpoint(Vector2 position)
    {
        lastCheckpoint = position;
    }

    public Vector2 GetCheckpoint()
    {
        return lastCheckpoint;
    }
    public void SetCPStatus(bool value)
    {
        isCheckStatus = value;
    }

    public bool GetCPStatus()
    {
        return isCheckStatus;
    }

    public void SetLastPH(float value)
    {
        lastPlayerHealth = value;
    }
    public float GetLastPH()
    {
        return lastPlayerHealth;
    }

}

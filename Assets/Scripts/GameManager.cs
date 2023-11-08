using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int score;
    private float scorePerSecond;
    private int highScore;
    private int fishItem;
    private int foodItem;
    private int level;
    private float lastPlayerHealth;
    private bool isCheckStatus = false;
    private Vector2 lastCheckpoint;

    // void FixedUpdate()
    // {
    //     // Count Time
    //     // scorePerSecond += 1f * Time.fixedDeltaTime;
    //     // score = (int)scorePerSecond;
    //     // Debug.Log(scorePerSecond);
    // }
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

    private void Awake()
    {
        Debug.Log($"Highscore : {highScore}");
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
            GameManager.Instance.SetHighScore(score);
            Debug.Log("Sukses Menambahkan Highscore");
            Debug.Log($"Highscore : {highScore}");
        }
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
        GameManager.Instance.SetScore(point);
    }
    public int GetFoodItem()
    {
        return foodItem;
    }

    public void SetFoodItem(int value)
    {
        int point = 50;
        foodItem = value;
        GameManager.Instance.SetScore(point);
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

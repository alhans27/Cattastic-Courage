using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int score;
    private int highScore;
    private int fishItem;
    private int foodItem;
    private int level;

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

}

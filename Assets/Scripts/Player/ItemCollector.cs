using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fishItem;
    private int foodItem;
    private int score;

    [SerializeField] private Text fishItemText;
    [SerializeField] private Text foodItemText;
    [SerializeField] private Text scoreText;

    private void Awake()
    {
        score = GameManager.Instance.GetScore();
        scoreText.text = $"Score : {score}";
        fishItemText.text = "0";
        foodItemText.text = "0";
    }

    private void Update()
    {
        score = GameManager.Instance.GetScore();
        scoreText.text = $"Score : {score}";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fish Item"))
        {
            fishItem++;
            Destroy(other.gameObject);
            GameManager.Instance.SetFishItem(fishItem);
            fishItemText.text = fishItem.ToString();
        }

        if (other.gameObject.CompareTag("Food Item"))
        {
            foodItem++;
            Destroy(other.gameObject);
            GameManager.Instance.SetFoodItem(fishItem);
            foodItemText.text = foodItem.ToString();
        }
    }
}

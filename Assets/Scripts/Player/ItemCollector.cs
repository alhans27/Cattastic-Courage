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
    [SerializeField] private AudioSource collectItemSound;

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
            collectItemSound.Play();
            other.gameObject.SetActive(false);
            GameManager.Instance.SetFishItem(fishItem);
            fishItemText.text = fishItem.ToString();
        }

        if (other.gameObject.CompareTag("Food Item"))
        {
            foodItem++;
            collectItemSound.Play();
            other.gameObject.SetActive(false);
            GameManager.Instance.SetFoodItem(fishItem);
            foodItemText.text = foodItem.ToString();
        }
    }
}

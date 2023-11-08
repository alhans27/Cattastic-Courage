using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI inputScore;
    private int inputScore;
    [SerializeField] private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        inputScore = GameManager.Instance.GetHighScore();
        Debug.Log($"Ini input Highscore yang di dapat: {inputScore}");
        submitScoreEvent.Invoke(inputName.text, inputScore);
    }

}

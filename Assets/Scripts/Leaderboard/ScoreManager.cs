using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int inputScore;
    private string inputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        inputName = Storage.playerName;
        if (inputName != null)
        {
            // inputScore = GameManager.Instance.GetHighScore();
            inputScore = Storage.highScore;
            Debug.Log($"Ini input Highscore yang di dapat: {inputScore}");
            submitScoreEvent.Invoke(inputName, inputScore);
        }
        else
        {
            Debug.Log("Gagal Input Nama");
        }
    }

}

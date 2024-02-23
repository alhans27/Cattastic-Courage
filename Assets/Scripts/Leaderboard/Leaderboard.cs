using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicKey =
        "226a36fa578ed1be200eff0bdcf75b2484ee9f6845f55f3ed8e75c85dbb604c2";
    // private string secretKey =
    //     "662b3d9504c806d7a2337d19f571afa9c2405237750ba720a20ec85ab0864e8b337f2fcdf47e6e99cbb7a201b6213237ab23e429a7c8c8058638c6c2e2dde1d398938ccedd82f5debc1836e54a8dac98b3bff47fb2e338089f75b49dcaa3d1d17a3e695fa85d7d8a349224d15bca93bdec5bc3980a781ee8e1e2e198db7403b4";

    private void Start()
    {
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        // int score = GameManager.Instance.GetHighScore();
        LeaderboardCreator.UploadNewEntry(publicKey, username, score, ((msg) =>
        {
            LeaderboardCreator.ResetPlayer();
            Debug.Log("Sukses");
            GetLeaderboard();
        }));
    }
}

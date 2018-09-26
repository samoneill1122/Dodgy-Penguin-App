using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowLeaderboard : MonoBehaviour {

    public Text[] highscoresText;
    GameObject leaderboard;

    void Start()
    {
        leaderboard = GameObject.Find("LeaderboardScripts");
        for (int i = 0; i < highscoresText.Length; i++)
        {
            highscoresText[i].text = i + 1 + ". Fetching...";
        }

        StartCoroutine(leaderboard.GetComponent<Leaderboard>().RefreshHighScores());
    }
}

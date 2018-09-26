using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour {

    const string privateCode = "hxdWYzn7gUiBhWXVGlF4DQWCIYobS6w0aNx5pN9QYA5A";
    const string publicCode = "5b6080fe191a8b0bcc7125dd";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    public static Leaderboard instance;
    GameObject myGameObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        if(myGameObject == null)
        {
            myGameObject = GameObject.Find("ShowLeaderboard");
        }
    }

    public static void AddNewHighScore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighScore(username, score));
    }
     
    IEnumerator UploadNewHighScore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if(string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            DownloadHighScores();
        }
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighScores()
    {
        StartCoroutine("DownloadHighScoresFromDatabase");
    }

    IEnumerator DownloadHighScoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScores(www.text);
            OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for(int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }

    public struct Highscore
    {
        public string username;
        public int score;

        public Highscore(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }

    public void OnHighscoresDownloaded(Leaderboard.Highscore[] highscoreList)
    {
        for (int i = 0; i < myGameObject.GetComponent<ShowLeaderboard>().highscoresText.Length; i++)
        {
            myGameObject.GetComponent<ShowLeaderboard>().highscoresText[i].text = i + 1 + ". ";
            if (highscoreList.Length > i)
            {
                myGameObject.GetComponent<ShowLeaderboard>().highscoresText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    public IEnumerator RefreshHighScores()
    {
        while (true)
        {
            DownloadHighScores();
            yield return new WaitForSeconds(30f);
        }
    }

}


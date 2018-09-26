using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUsername : MonoBehaviour {

    public static bool usernameIsTaken = false;
    const string publicCode = "5b6080fe191a8b0bcc7125dd";
    const string webURL = "http://dreamlo.com/lb/";
    public GameObject usernameObject;
    public static GetUsername instance;
    public static bool done;

    void Awake()
    {
        instance = this;
    }

	public void GetInput(string input)
    {
        done = false;
        Debug.Log("You entered " + input);
        StartCoroutine(DownloadOneScoreFromDatabase(input));
    }

    public static IEnumerator DownloadOneScoreFromDatabase(string name)
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            GetSingleScore(www.text, name);
        }
    }


    public static void GetSingleScore(string textStream, string playerName)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            if (username == playerName)
            {
                usernameIsTaken = true;
            }
            else
            {
                usernameIsTaken = false;
            }
        }

        if (usernameIsTaken == true)
        {
            instance.StartCoroutine("_UsernameTaken");
        }
        else
        {
            PlayerPrefs.SetString("SaveName", playerName);
            done = true;
        }
    }

    IEnumerator _UsernameTaken()
    {
        usernameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        usernameObject.SetActive(false);
    }

}

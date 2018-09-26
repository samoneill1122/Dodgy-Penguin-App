using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetUsername : MonoBehaviour
{

    public GameObject usernameObject;

    public void Continue()
    {
        StartCoroutine("_WaitForFirstFunction");
    }

    IEnumerator _WaitForFirstFunction()
    {
        yield return new WaitUntil(() => PlayerPrefs.GetString("SaveName") != "");
        if(GetUsername.usernameIsTaken == false)
        {
            SceneManager.LoadScene("Level01");
        }
        else
        {
            yield return null;
        }
    }

}

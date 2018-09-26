using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject usernameMenu;
    public static bool usernameSet;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("SaveName"));
    }

    void Update()
    {
        if (PlayerPrefs.GetString("SaveName") == "")
        {
            usernameSet = false;
        }
        else if (PlayerPrefs.GetString("SaveName") != "")
        {
            usernameSet = true;
        }
    }

    public void PlayGame()
	{
        if(usernameSet != true)
        {
            mainMenu.SetActive(false);
            usernameMenu.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Level01");
        }
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}

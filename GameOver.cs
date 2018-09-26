using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    int rand;
    public GameObject gameOverMenu;
    public GameObject rateGame;

    void Start()
    {
        rand = Random.Range(1, 10);
        if(rand == 7)
        {
            gameOverMenu.SetActive(false);
            rateGame.SetActive(true);
        }
    }

	public void RestartGame()
	{
		SceneManager.LoadScene("Level01");
    }

	public void QuitGame()
	{
		Application.Quit();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
    }

}


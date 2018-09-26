using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;
    public static int originalHighScore;

    void Start()
	{
		highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        originalHighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

	void Update()
	{
		int number = SnowballCol.count;
		scoreText.text = SnowballCol.count.ToString("0"); 

		if(number > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", number);
			highScoreText.text = number.ToString();
		}
	}
    
}

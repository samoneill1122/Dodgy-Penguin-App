using UnityEngine;
using UnityEngine.UI;

public class ColourChange : MonoBehaviour {

	public float countDownStart = 2f;
	public float countDown = 2f;

	void Update()
	{
		changeColour();
	}

	void changeColour()
	{
		countDown -= Time.deltaTime;
		if(countDown > 1 && countDown <= countDownStart)
		{
			GetComponent<Text>().color = Color.white;
		}
		if(countDown > 0 && countDown <= 1)
		{
			GetComponent<Text>().color = Color.red;
		}
		if(countDown <= 0)
		{
			GetComponent<Text>().color = Color.white;
			countDown = countDownStart;
		}
	}

}

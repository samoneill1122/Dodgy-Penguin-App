using UnityEngine;
using UnityEngine.UI;

public class resetButton : MonoBehaviour {

	public void Reset()
	{
		PlayerPrefs.DeleteKey("HighScore");
	}

}

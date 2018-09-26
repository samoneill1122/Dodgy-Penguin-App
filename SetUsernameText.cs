using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUsernameText : MonoBehaviour {

    public InputField myInputField;

	// Use this for initialization
	void Start ()
    {
        myInputField.text = PlayerPrefs.GetString("SaveName");
	}

    public void SetText(string input)
    {
        myInputField.text = input;
    }

}

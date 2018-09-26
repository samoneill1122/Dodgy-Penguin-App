using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotate : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.GetComponent<Transform>().eulerAngles != new Vector3(0f, 0f, 0f))
        {
            gameObject.GetComponent<Transform>().eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if(gameObject.name == "WalrusRight")
        {
            if (gameObject.GetComponent<Transform>().position.x >= 2.25)
            {
                Destroy(gameObject);
            }
        }
        if (gameObject.name == "WalrusLeft")
        {
            if (gameObject.GetComponent<Transform>().position.x <= -2.25)
            {
                Destroy(gameObject);
            }
        }
    }
}

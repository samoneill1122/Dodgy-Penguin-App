using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppRating : MonoBehaviour {

    public void RateApp()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.SamONeill.DodgyPenguin");
    }

}

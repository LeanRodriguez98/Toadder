using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {
    public Text pointsText;
    public Text TimeText;
    private bool Show;
    private void Start()
    {
        Show = true;
    }
    void Update () {
        if (Show)
        {
            if(pointsText.enabled == true)
                pointsText.text = "Points: " + PlayerStats.Instancie.Points.ToString("0000");
            if (TimeText.enabled == true)
                TimeText.text = "Time: " + ((int)PlayerStats.Instancie.Minutes).ToString("00") + ":" + ((int)PlayerStats.Instancie.Seconds).ToString("00");
            Show = false;
        }
    }
}

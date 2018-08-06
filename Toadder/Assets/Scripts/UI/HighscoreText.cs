using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreText : MonoBehaviour {

    public Text[] HighscoreTexts;

    void Start()
    {
        if (HighscoreManager.Instancie != null)
        {
            for (int i = 0; i < HighscoreTexts.Length; i++)
            {
                HighscoreTexts[i].text = HighscoreManager.Instancie.ScoreList[i].ToString("0000");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject GameOverPanel;
    public GameObject NextLevelPanel;

    void Start () {
        GameOverPanel.SetActive(false); 
        NextLevelPanel.SetActive(false);
    }
	
	
	void Update () {
        if (ToadController.instance.lifes <= 0)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
        if (ToadController.instance != null)       
            if (EndLevelController.Instancie.trigger)
            {
                Time.timeScale = 0;
                NextLevelPanel.SetActive(true);
            }
    }
}

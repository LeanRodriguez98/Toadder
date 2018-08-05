using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_ButtonsManager : MonoBehaviour {
    public Object MainMenuScene;
    public GameObject PauseButton = null;
    public GameObject ResumeButton = null;
    public GameObject BackToMainMenuButton = null;
    public GameObject ControlsImage = null;
   /* public GameObject UpArrowAndSpace = null;
    public Text RotateShip = null;
    public Text ActivatePropulsion = null;*/
    void Start()
    {
        if (PauseButton != null)
            PauseButton.SetActive(true);
        if (ResumeButton != null)
            ResumeButton.SetActive(false);
        if (BackToMainMenuButton != null)
            BackToMainMenuButton.SetActive(false);
        if (ControlsImage != null)
            ControlsImage.SetActive(false);
        /*if (UpArrowAndSpace != null)
            UpArrowAndSpace.SetActive(false);
        if (RotateShip != null)
            RotateShip.enabled = false;
        if (ActivatePropulsion != null)
            ActivatePropulsion.enabled = false;*/
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        ResumeButton.SetActive(true);
        BackToMainMenuButton.SetActive(true);
        ControlsImage.SetActive(true);
      /*  UpArrowAndSpace.SetActive(true);
        RotateShip.enabled = true;
        ActivatePropulsion.enabled = true;*/
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
        BackToMainMenuButton.SetActive(false);
        ControlsImage.SetActive(false);
       /* UpArrowAndSpace.SetActive(false);
        RotateShip.enabled = false;
        ActivatePropulsion.enabled = false;*/
    }

    public void Test()
    {
        Debug.Log("TEST");
    }

    public void Change_Scense(Object Level)
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }

        SceneManager.LoadScene(Level.name);
    }

    public void BackToMainMenu()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        if (LoadingScenes.Instancie != null)
        {
            LoadingScenes.Instancie.Level = 1;
        }
        if (PlayerStats.Instancie != null)
        {
            PlayerStats.Instancie.Points = 0;
        }

        SceneManager.LoadScene(MainMenuScene.name);

    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

   
    
}


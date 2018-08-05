using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour {

    public static LoadingScenes Instancie;
    public Object[] Levels;
    public Object LoadingScene;
    public Object credits;
    [HideInInspector] public int Level;
    [HideInInspector] public string LoadingText;
    public float LoadingTime;
    private float Percentage;
    private float AuxLoadingTime;

    void Awake()
    {
        if (Instancie == null)
        {
            Instancie = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Percentage = 0;
        Level = 1;
        AuxLoadingTime = 0;
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == LoadingScene.name)
            UpdatePercentage();
        if (Percentage > 100)
        {
            Percentage = 0;
            AuxLoadingTime = 0;
            NextLevel();
        }
    }

    public void UpdatePercentage()
    {
        if(Level - 1 < Levels.Length)
        LoadingText = "Loading Level " + Level + " % " + ((int)Percentage).ToString("000");
        else
        LoadingText = "Loading credits"+ " % " + ((int)Percentage).ToString("000");
        if (AuxLoadingTime < LoadingTime)
        AuxLoadingTime += Time.deltaTime;
        Percentage = AuxLoadingTime * (100 / LoadingTime);
    }
    public void NextLevel()
    {

        if (Level - 1 < Levels.Length)
            SceneManager.LoadScene(Levels[Level - 1].name);
        else
            SceneManager.LoadScene(credits.name);      
        Level++;

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreManager : MonoBehaviour {

    public static HighscoreManager Instancie;
    [HideInInspector] public List<int> ScoreList = new List<int>();
    [HideInInspector] public bool AsignHishcore;
    public int CantHighscores;
    public Object LoadingScenes;
    public Object[] Levels;

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
        AsignHishcore = true;
        for (int i = 0; i < CantHighscores; i++)
        {
            ScoreList.Add(0);
        }
    }


    void Update()
    {

        if (SceneManager.GetActiveScene().name == LoadingScenes.name && !AsignHishcore)
        {
            AsignHishcore = true;
        }

        for (int i = 0; i < Levels.Length; i++)
        {
            if (ToadController.instance.lifes <= 0 && AsignHishcore && SceneManager.GetActiveScene().name == Levels[i].name)
            {

                ScoreList.Add(PlayerStats.Instancie.Points);
                ScoreList.Sort();
                ScoreList.Reverse();
                AsignHishcore = false;
            }
        }
    }
}



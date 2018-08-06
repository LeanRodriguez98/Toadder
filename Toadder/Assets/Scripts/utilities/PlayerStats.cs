using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
    public static PlayerStats Instancie;
    public Object LoadingScene;
    [HideInInspector] public int Points;
    [HideInInspector] public int Minutes;
    [HideInInspector] public int Seconds;
    private float GameTime;

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


    private void Update()
    {
        if (SceneManager.GetActiveScene().name != LoadingScene.name)
        {
            GameTime += Time.deltaTime;
            if (GameTime > 1)
            {
                Seconds++;
                GameTime = 0;
            }
            if (Seconds >= 60)
            {
                Minutes++;
                Seconds = 0;
            }
        }

        if (ToadController.instance != null)
            if (ToadController.instance.points != Points)
                Points = ToadController.instance.points;
    }
}

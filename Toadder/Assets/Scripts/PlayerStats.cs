using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
    public static PlayerStats Instancie;
    public Object LoadingScene;
    [HideInInspector] public int Points;
    [HideInInspector] public float GameTime;

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
        }
        if (ToadController.instance != null)
            if (ToadController.instance.points != Points)
                Points = ToadController.instance.points;
    }
}

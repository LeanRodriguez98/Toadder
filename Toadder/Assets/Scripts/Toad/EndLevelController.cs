using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelController : MonoBehaviour
{
    public Object LoadingScene;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Descktop")    
            SceneManager.LoadScene(LoadingScene.name);    
    }
}

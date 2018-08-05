using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LoadingText : MonoBehaviour {
    public Text Loading;

    void Update()
    {
        Loading.text = LoadingScenes.Instancie.LoadingText;
    }
}

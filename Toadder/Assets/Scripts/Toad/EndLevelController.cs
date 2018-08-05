using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndLevelController : MonoBehaviour
{
    public static EndLevelController Instancie;
    public bool trigger;
    void Awake()
    {
        Instancie = this;
        trigger = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Descktop")
            trigger = true;
    }
}

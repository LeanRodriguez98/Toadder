using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementColliders : MonoBehaviour
{
    [HideInInspector]
    public bool trigger;

    private Vector3 startPosition;
    private Vector3 position;
    void Start()
    {
        startPosition = position = transform.position;
    }
    void Update()
    {
        position.x = ToadController.instance.transform.position.x + startPosition.x;
        position.z = ToadController.instance.transform.position.z + startPosition.z;
        transform.position = position;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            trigger = true;
         
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            trigger = false;
        }
    }
}
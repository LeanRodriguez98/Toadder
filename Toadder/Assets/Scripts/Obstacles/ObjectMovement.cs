using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {
    public GameObject terrain; 
    public float speedMovement;
    [HideInInspector]
    public Vector3 spawnPosition;
	// Use this for initialization
	void Start () {
        spawnPosition = transform.position;
        if (spawnPosition.x < 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }

    // Update is called once per frame
    void Update () {
        if (spawnPosition.x < 0)
        {
            transform.position += Vector3.right * Time.deltaTime *  speedMovement;
            if (transform.position.x - spawnPosition.x > terrain.transform.localScale.x)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * speedMovement;
            if (transform.position.x - spawnPosition.x < -terrain.transform.localScale.x)
            {
                Destroy(gameObject);
            }
        }
	}
}

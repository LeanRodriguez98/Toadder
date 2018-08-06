using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitsPosition : MonoBehaviour {
    private Vector3 position;
	// Use this for initialization
	void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (ToadController.instance != null)
        {
            position.z = ToadController.instance.transform.position.z;
            transform.position = position;
        }
        
	}
}

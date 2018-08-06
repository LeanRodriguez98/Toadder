using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescktopMovement : MonoBehaviour {
    private Vector3 StartToadPosition;
    private Vector3 ActuialToadPosition;
    private Vector3 DescktopPosition;
	// Use this for initialization
	void Start () {
        if(ToadController.instance!=null)
            StartToadPosition = ToadController.instance.transform.position;
        DescktopPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (ToadController.instance != null)
            ActuialToadPosition = ToadController.instance.transform.position;
        DescktopPosition.z = -(ActuialToadPosition.z - StartToadPosition.z);
        if(transform.position != DescktopPosition)
        transform.position = DescktopPosition;
    }
}

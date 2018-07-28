using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Vector3 cameraOffset;
    public Vector3 cameraRotation;
    private Vector3 cameraPosition;
    // Use this for initialization
    void Start()
    {
        cameraPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ToadController.instance != null)
        {
            cameraPosition.x = ToadController.instance.transform.position.x + cameraOffset.x;
            cameraPosition.z = ToadController.instance.transform.position.z + cameraOffset.z;
            transform.position = cameraPosition;
            transform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, cameraRotation.z);
        }
        
    }
}

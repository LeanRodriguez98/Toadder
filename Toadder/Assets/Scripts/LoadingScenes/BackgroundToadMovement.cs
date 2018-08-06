using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundToadMovement : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 position;
    private Vector3 addForce;
    public float timer;
    public float jumpForce;
    private float auxTimer;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        position = transform.position;
        addForce.x = 1;
        addForce.y = 1;
        addForce.z = 0;
        auxTimer = timer;
    }
	
	// Update is called once per frame
	void Update () {
        auxTimer += Time.deltaTime;
        if (auxTimer > timer)
        {
            rb.AddForce(addForce * jumpForce);
            auxTimer = 0;
        }
        
    }
}

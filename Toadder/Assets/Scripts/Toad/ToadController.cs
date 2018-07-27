using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadController : MonoBehaviour
{
    public float movementTolerance;
    public float jumpForce;
    public float JumpDistance;

    private float jumpStartHeight;
    private bool inputMovement;
    private Vector3 position;
    private Vector3 auxPosition;
    private Vector3 JumpStartPosition;
    private Rigidbody rb;
  


    // Use this for initialization
    void Start()
    {
        inputMovement = true;
        position = transform.position;
        auxPosition = transform.position;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        auxPosition.y = transform.position.y;

        if (inputMovement)
        {
            if (Input.GetKeyDown(KeyCode.W))
                auxPosition.z += JumpDistance;
            if (Input.GetKeyDown(KeyCode.S))
                auxPosition.z -= JumpDistance;
            if (Input.GetKeyDown(KeyCode.A))
                auxPosition.x -= JumpDistance;
            if (Input.GetKeyDown(KeyCode.D))
                auxPosition.x += JumpDistance;

            if (auxPosition.x > position.x + movementTolerance ||
                auxPosition.x < position.x - movementTolerance ||
                auxPosition.z > position.z + movementTolerance ||
                auxPosition.z < position.z - movementTolerance)
            {
                inputMovement = false;
                jumpStartHeight = transform.position.y;
            }
            position.y = transform.position.y;
        }

        if (!inputMovement)
        {
            UpdateJumpHeight();

            if (auxPosition.x > position.x + movementTolerance)            
                position.x += Time.deltaTime;            
            else if (auxPosition.x < position.x - movementTolerance)            
                position.x -= Time.deltaTime;            
            else if (auxPosition.z > position.z + movementTolerance)            
                position.z += Time.deltaTime;            
            else if (auxPosition.z < position.z - movementTolerance)            
                position.z -= Time.deltaTime;            
            else            
                inputMovement = true;            
        }
        transform.position = position;
    }


    void UpdateJumpHeight()
    {
        if (Mathf.Abs(auxPosition.z - position.z) > movementTolerance)
            position.y = -((-(JumpDistance / 2 * JumpDistance / 2) * jumpForce) + ((-JumpDistance / 2) + (Mathf.Abs(auxPosition.z - position.z))) * ((-JumpDistance / 2) + (Mathf.Abs(auxPosition.z - position.z))) * jumpForce) + jumpStartHeight;

        if (Mathf.Abs(auxPosition.x - position.x) > movementTolerance)
            position.y = -((-(JumpDistance / 2 * JumpDistance / 2) * jumpForce) + ((-JumpDistance / 2) + (Mathf.Abs(auxPosition.x - position.x))) * ((-JumpDistance / 2) + (Mathf.Abs(auxPosition.x - position.x))) * jumpForce) + jumpStartHeight;
    }
}


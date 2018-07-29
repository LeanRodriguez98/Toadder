using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadController : MonoBehaviour
{
    public static ToadController instance;
    public float movementTolerance;
    public float jumpForce;
    public float JumpDistance;
    public float timeDeadCamera;
    public int lifes;
    public GameObject bloodParticles;
    public GameObject whaterParticles;
    public List<Vector3> characterRotations;
    public List<GameObject> MovementColliders;
    private float jumpStartHeight;
    private float tableSpeed;
    private float auxTimeDeadCamera;
    private bool inputMovement;
    private bool tableMovement;
    private bool directionTable;
    private bool lifeDown;
    private Vector3 position;
    private Vector3 auxPosition;
    private Vector3 startPosition;
    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        inputMovement = true;
        tableMovement = false;
        lifeDown = false;
        position = transform.position;
        auxPosition = transform.position;
        startPosition = transform.position;
        auxTimeDeadCamera = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(lifeDown)
        LifeDown();
    }

    void Movement()
    {
        auxPosition.y = transform.position.y;
        if (!lifeDown)
        {


            if (inputMovement)
            {
                if (Input.GetKeyDown(KeyCode.W) && !MovementColliders[0].gameObject.GetComponent<MovementColliders>().trigger)
                {
                    auxPosition.z += JumpDistance;
                    transform.eulerAngles = characterRotations[0];
                    tableMovement = false;
                }
                if (Input.GetKeyDown(KeyCode.S) && !MovementColliders[1].gameObject.GetComponent<MovementColliders>().trigger)
                {
                    auxPosition.z -= JumpDistance;
                    transform.eulerAngles = characterRotations[2];
                    tableMovement = false;
                }
                if (Input.GetKeyDown(KeyCode.A) && !MovementColliders[2].gameObject.GetComponent<MovementColliders>().trigger)
                {
                    auxPosition.x -= JumpDistance;
                    transform.eulerAngles = characterRotations[3];
                    tableMovement = false;
                }
                if (Input.GetKeyDown(KeyCode.D) && !MovementColliders[3].gameObject.GetComponent<MovementColliders>().trigger)
                {
                    auxPosition.x += JumpDistance;
                    transform.eulerAngles = characterRotations[1];
                    tableMovement = false;
                }

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

            if (tableMovement)
            {
                if (directionTable)
                {
                    transform.position += Vector3.right * Time.deltaTime * tableSpeed;
                }
                else
                {
                    transform.position += Vector3.left * Time.deltaTime * tableSpeed;
                }
                position = transform.position;
                auxPosition = position;

            }
            else
            {
                transform.position = position;
            }
        }
    }

    void LifeDown()
    {
        auxTimeDeadCamera += Time.deltaTime;
        if (auxTimeDeadCamera >= timeDeadCamera)
        {
            lifes--;
            transform.position = startPosition;
            position = transform.position;
            auxPosition = transform.position;
            auxTimeDeadCamera = 0;
            lifeDown = false;
            tableMovement = false;

            if (lifes <= 0)
            {
                Destroy(gameObject);
            }
            GetComponentInChildren<MeshRenderer>().enabled = true;

        }


    }

    void UpdateJumpHeight()
    {
        if (Mathf.Abs(auxPosition.z - position.z) > movementTolerance)
            position.y = -((-(JumpDistance / 2 * JumpDistance / 2) * jumpForce) + ((-JumpDistance / 2) + (Mathf.Abs(auxPosition.z - position.z))) * ((-JumpDistance / 2) + (Mathf.Abs(auxPosition.z - position.z))) * jumpForce) + jumpStartHeight;

        if (Mathf.Abs(auxPosition.x - position.x) > movementTolerance)
            position.y = -((-(JumpDistance / 2 * JumpDistance / 2) * jumpForce) + ((-JumpDistance / 2) + (Mathf.Abs(auxPosition.x - position.x))) * ((-JumpDistance / 2) + (Mathf.Abs(auxPosition.x - position.x))) * jumpForce) + jumpStartHeight;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Whater")
        {
            lifeDown = true;
            GetComponentInChildren<MeshRenderer>().enabled = false;
            Instantiate(whaterParticles, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Car")
        {
            lifeDown = true;
            GetComponentInChildren<MeshRenderer>().enabled = false;
            Instantiate(bloodParticles,transform.position,Quaternion.identity);
        }
        if (collision.gameObject.tag == "Table")
        {
            tableMovement = true;
            tableSpeed = collision.gameObject.GetComponent<ObjectMovement>().speedMovement;
            if (collision.gameObject.GetComponent<ObjectMovement>().spawnPosition.x < 0)
            {
                directionTable = true;
            }
            else
            {
                directionTable = false;
            }
        }
    }
    

}


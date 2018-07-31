using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour {
    public float TimeUp;
    public float TimeDown;
    private float auxTimeUp;
    private float auxTimeDown;
    private Vector3 upPosition;
    private Vector3 downPosition;
    private Vector3 position;
	// Use this for initialization
	void Start () {
        upPosition = transform.position;
        downPosition = transform.position;
        downPosition.y = downPosition.y - transform.localScale.y;
        auxTimeUp = 0;
        auxTimeDown = 0;
    }
	
	// Update is called once per frame
	void Update () {
        position = transform.position;

        if (auxTimeDown < TimeUp)
        {
            auxTimeDown += Time.deltaTime;
        }
        else if (auxTimeDown >= TimeUp && position.y >= downPosition.y && auxTimeUp < TimeDown)
        {
            position.y -= Time.deltaTime;
        }
        else if (auxTimeUp < TimeDown)
        {
            auxTimeUp += Time.deltaTime;
        }
        else if(auxTimeUp >= TimeDown && position.y <= upPosition.y)
        {
            position.y += Time.deltaTime;
        }
        else
        {
            auxTimeUp = 0;
            auxTimeDown = 0;
        }
        transform.position = position;
    }
}

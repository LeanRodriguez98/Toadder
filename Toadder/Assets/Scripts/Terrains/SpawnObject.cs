using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    public GameObject[] objects;
    public float maxSpawnTimer;
    public float minSpawnTimer;
    public bool randomSpawn;
    public bool direction;
    private float spawnTimer;
    private float auxTimer;
    private int randomObject;
	// Use this for initialization
	void Start () {
        auxTimer = 0;
        spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
        if (randomSpawn)
        {
            int aux;
            aux = Random.Range(0, 2);
            if (aux == 1)
            {
                direction = true;
            }
            else
            {
                direction = false;
            }
        }
        auxTimer = Random.Range(minSpawnTimer, maxSpawnTimer);

}

// Update is called once per frame
void Update () {
        auxTimer += Time.deltaTime;
        if (auxTimer > spawnTimer)
        {
            randomObject = Random.Range(0, objects.Length);
            if (direction)
            {
                Instantiate(objects[randomObject], new Vector3(transform.position.x - transform.localScale.x / 2, (transform.position.y + (transform.localScale.y / 2)) + objects[randomObject].transform.localScale.y / 2, transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(objects[randomObject], new Vector3(transform.position.x + transform.localScale.x / 2, (transform.position.y + (transform.localScale.y / 2)) + objects[randomObject].transform.localScale.y / 2, transform.position.z), Quaternion.identity);
            }
            auxTimer = 0;
            spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
        }
	}
}

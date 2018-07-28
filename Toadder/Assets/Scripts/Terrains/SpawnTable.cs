using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTable : MonoBehaviour {
    public GameObject table;
    public float maxSpawnTimer;
    public float minSpawnTimer;
    public bool direction;
    private float spawnTimer;
    private float auxTimer;
	// Use this for initialization
	void Start () {
        auxTimer = 0;
        spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
    }

    // Update is called once per frame
    void Update () {
        auxTimer += Time.deltaTime;
        if (auxTimer > spawnTimer)
        {
            if (direction)
            {
                Instantiate(table, new Vector3(transform.position.x - transform.localScale.x / 2, (transform.position.y + (transform.localScale.y / 2)) + table.transform.localScale.y / 2, transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(table, new Vector3(transform.position.x + transform.localScale.x / 2, (transform.position.y + (transform.localScale.y / 2)) + table.transform.localScale.y / 2, transform.position.z), Quaternion.identity);
            }
            auxTimer = 0;
            spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
        }
	}
}

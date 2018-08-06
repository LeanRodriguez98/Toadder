using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitLevelGenerator : MonoBehaviour {
    public GameObject toad;
    public GameObject[] terrains;
    public GameObject[] swichableObject;
    public GameObject treesTerrain;
    public GameObject tree;
    public int spawnObstacleProbability;
    public int StartTerrainsToGenerate;
    public int distanceGenerate;
    private int randomTerrain;
    private int longOfLevel;
    private int auxDistanceGenerate;
    private float heightSpawnTerrain;
    private bool auxSwichTerrain;
	// Use this for initialization
	void Start () {
        Instantiate(toad, new Vector3(0, 1, 0), Quaternion.identity);
        randomTerrain = 0;
        longOfLevel = 0;
        heightSpawnTerrain = treesTerrain.gameObject.GetComponent<Transform>().transform.localScale.y / 2;
        auxSwichTerrain = true;
        auxDistanceGenerate = distanceGenerate;
        Instantiate(treesTerrain, new Vector3(0, 0, -1), Quaternion.identity);
        Instantiate(treesTerrain, new Vector3(0, 0, -2), Quaternion.identity);

        for (int i = 0; i < StartTerrainsToGenerate; i++)
        {
            Instantiate(terrains[randomTerrain], new Vector3(0, terrains[randomTerrain].gameObject.GetComponent<Transform>().transform.localScale.y/2 - heightSpawnTerrain, i), Quaternion.identity);

            for (int j = 0; j < swichableObject.Length; j++)
            {
                if (terrains[randomTerrain] == swichableObject[j] && auxSwichTerrain)
                {
                    if (j == swichableObject.Length - 1 )
                    {
                        terrains[randomTerrain] = swichableObject[0];                        
                    }
                    else
                    {
                        terrains[randomTerrain] = swichableObject[j+1];                        
                    }
                    auxSwichTerrain = false;
                }
            }

            if (terrains[randomTerrain] == treesTerrain)
            {
                for (int j = (int)(-treesTerrain.gameObject.GetComponent<Transform>().localScale.x/2 + 1); j < treesTerrain.gameObject.GetComponent<Transform>().localScale.x/2; j++)
                {
                    if (!(i == 0 && j == toad.gameObject.GetComponent<Transform>().transform.position.x))
                    {
                        if (Random.Range(1, 100) < spawnObstacleProbability)
                        {
                            Instantiate(tree, new Vector3(j, treesTerrain.gameObject.GetComponent<Transform>().localScale.y / 2, i), Quaternion.identity);
                        }
                    }
                }
            }

            randomTerrain = Random.Range(0, terrains.Length);
            auxSwichTerrain = true;
            longOfLevel++;
        }
    }
	
	// Update is called once per frame
	void Update () {     

        if (ToadController.instance != null)
        {
            if (ToadController.instance.transform.position.z > distanceGenerate)
            {
                for (int i = 0; i < distanceGenerate; i++)
                {
                    Instantiate(terrains[randomTerrain], new Vector3(0, terrains[randomTerrain].gameObject.GetComponent<Transform>().transform.localScale.y / 2 - heightSpawnTerrain, longOfLevel), Quaternion.identity);

                    for (int j = 0; j < swichableObject.Length; j++)
                    {
                        if (terrains[randomTerrain] == swichableObject[j] && auxSwichTerrain)
                        {
                            if (j == swichableObject.Length - 1)
                            {
                                terrains[randomTerrain] = swichableObject[0];
                            }
                            else
                            {
                                terrains[randomTerrain] = swichableObject[j + 1];
                            }
                            auxSwichTerrain = false;
                        }
                    }

                    if (terrains[randomTerrain] == treesTerrain)
                    {
                        for (int j = (int)(-treesTerrain.gameObject.GetComponent<Transform>().localScale.x / 2 + 1); j < treesTerrain.gameObject.GetComponent<Transform>().localScale.x / 2; j++)
                        {
                            if (!(i == 0 && j == toad.gameObject.GetComponent<Transform>().transform.position.x))
                            {
                                if (Random.Range(1, 100) < spawnObstacleProbability)
                                {
                                    Instantiate(tree, new Vector3(j, treesTerrain.gameObject.GetComponent<Transform>().localScale.y / 2, longOfLevel), Quaternion.identity);
                                }
                            }
                        }
                    }

                    randomTerrain = Random.Range(0, terrains.Length);
                    auxSwichTerrain = true;
                    longOfLevel++;
                }
                distanceGenerate += auxDistanceGenerate;
            }        
        }
	}
}

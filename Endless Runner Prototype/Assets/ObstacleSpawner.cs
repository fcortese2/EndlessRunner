using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    List<Transform> SpawnPointsA = new List<Transform>();
    List<Transform> SpawnPointsB = new List<Transform>();
    [Space]

    public GameObject[] ObstaclePool;
    public GameObject referenceObject;

    private int toSpawn;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.name[child.name.Length - 1] == 'A')
            {
                SpawnPointsA.Add(child);
            }
            if (child.name[child.name.Length - 1] == 'B')
            {
                SpawnPointsB.Add(child);
            }
        }

        for (int i = 0; i < SpawnPointsA.Count; i++)
        {
            usedA.Add(false);
        }
        for (int i = 0; i < SpawnPointsB.Count; i++)
        {
            usedB.Add(false);
        }

    }

    void Start()
    {
        toSpawn = Random.Range(0,100);

        if (toSpawn <= 30)
        {
            Spawn();
        }
        else if (toSpawn > 30 && toSpawn <=60)
        {
            Spawn(2);
        }
        else if (toSpawn > 60 && toSpawn < 85)
        {
            Spawn(3);
        }
        else if (toSpawn > 85)
        {
            Spawn(4);
        }
    }   

    void Spawn(int qty = 1)
    {
        if (qty == 1)
        {
            SpawnAtA();
        }
        else if (qty == 2)
        {
            Transform spawnAtPoint = SpawnPointsA[Random.Range(0, SpawnPointsA.Count)];
            SpawnAtA();

            SpawnAtB();
        }
        else if (qty == 3)
        {
            SpawnAtA();
            SpawnAtA();

            SpawnAtB();
        }
        else if (qty == 4)
        {
            SpawnAtA();
            SpawnAtA();

            SpawnAtB();
            SpawnAtB();
        }
    }

    #region SPAWN CODE
    List<bool> usedA = new List<bool>();
    List<bool> usedB = new List<bool>();
    private void SpawnAtA()
    {
        int spawnAt = Random.Range(0, SpawnPointsA.Count);
        if (usedA[spawnAt] == false)
        {
            usedA[spawnAt] = true;
            Transform spawnAtPoint = SpawnPointsA[spawnAt];
            Object.Instantiate(ObstaclePool[Random.Range(0, ObstaclePool.Length - 1)], spawnAtPoint.position, referenceObject.transform.rotation);
        }
        else
        {
            SpawnAtA();
            return;
        }
    }

    private void SpawnAtB()
    {
        int spawnAt = Random.Range(0, SpawnPointsB.Count);
        if (usedB[spawnAt] == false)
        {
            usedB[spawnAt] = true;
            Transform spawnAtPoint = SpawnPointsB[spawnAt];
            Object.Instantiate(ObstaclePool[Random.Range(0, ObstaclePool.Length - 1)], spawnAtPoint.position, referenceObject.transform.rotation);
        }
        else
        {
            SpawnAtB();
            return;
        }
    }
    #endregion
}

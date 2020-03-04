using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    List<Transform> SpawnPointsA = new List<Transform>();
    List<Transform> SpawnPointsB = new List<Transform>();
    private bool paused = false;

    [Header("Obstacle Setup")]
    public GameObject[] ObstaclePool;
    public GameObject referenceObject;

    [Header("Coin Setup")]
    public GameObject coinPrefab;
    public GameObject coinReferenceObject;

    [Header("Powerup Setup")]
    public GameObject[] powerupPool;

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
        if (!paused)
        {
            CallSpawnObstacles();
            CallSpawnCoin();
            CallSpawnPowerUp();
        }
        
    }   

    void CallSpawnObstacles()
    {
        toSpawn = Random.Range(0, 100);

        if (toSpawn <= 30)
        {
            Spawn();
        }
        else if (toSpawn > 30 && toSpawn <= 60)
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

    #region SPAWN OBSTACLE CODE
    List<bool> usedA = new List<bool>();
    List<bool> usedB = new List<bool>();
    private void SpawnAtA()
    {
        int spawnAt = Random.Range(0, SpawnPointsA.Count);
        if (usedA[spawnAt] == false)
        {
            usedA[spawnAt] = true;
            Transform spawnAtPoint = SpawnPointsA[spawnAt];
            Object.Instantiate(ObstaclePool[Random.Range(0, ObstaclePool.Length)], spawnAtPoint.position, referenceObject.transform.rotation);
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
            Object.Instantiate(ObstaclePool[Random.Range(0, ObstaclePool.Length)], spawnAtPoint.position, referenceObject.transform.rotation);
        }
        else
        {
            SpawnAtB();
            return;
        }
    }
    #endregion

    #region SPAWN COIN CODE
    private void CallSpawnCoin()
    {
        int ran = Random.Range(0, 100);
        if (ran <=50 )
        {
            SpawnCoin();
        }
        else
        {
            SpawnCoin(2);
        }
    }

    void SpawnCoin(int qty = 1)
    {
        for (int i = 0; i < qty; i++)
        {
            int ran = Random.Range(0, 100);
            if (ran <=50 )
            {
                spawnCoinAtA();
            }
            else
            {
                spawnCoinAtB();
            }
        }
    }

    void spawnCoinAtA()
    {
        List<Transform> pointsAvailable = new List<Transform>();

        for (int i = 0; i < usedA.Count; i++)
        {
            if (usedA[i] == false)
            {
                pointsAvailable.Add(SpawnPointsA[i]);
            }
        }
        if (pointsAvailable.Count == 0)
        {
            return;
        }

        int ran = Random.Range(0, pointsAvailable.Count);

        Object.Instantiate(coinPrefab, pointsAvailable[ran].position, coinPrefab.transform.rotation);
        usedA[ran] = true;

    }

    void spawnCoinAtB()
    {
        List<Transform> pointsAvailable = new List<Transform>();

        for (int i = 0; i < usedB.Count; i++)
        {
            if (usedB[i] == false)
            {
                pointsAvailable.Add(SpawnPointsB[i]);
            }
        }
        if (pointsAvailable.Count == 0)
        {
            return;
        }

        int ran = Random.Range(0, pointsAvailable.Count);

        Object.Instantiate(coinPrefab, pointsAvailable[ran].position, coinPrefab.transform.rotation);
        usedB[ran] = true;
    }

    #endregion

    private void CallSpawnPowerUp()
    {
        bool free = false;
        int freeSpot = 0;
        for (int i = 0; i < usedA.Count; i++)
        {
            if ((usedA[i] == false) && (free == false))
            {
                free = true;
                freeSpot = i;
            }
            
        }
        if (free == true)
        {
            if (Random.Range(0, 100) <= 8)
            {
                SpawnPowerupAtA(freeSpot);
            }
        }
        else if (free==false)
        {
            for (int i = 0; i < usedB.Count; i++)
            {
                if ((usedA[i] == false) && (free == false))
                {
                    free = true;
                    freeSpot = i;
                }
            }
            if (free == true)
            {
                if (Random.Range(0, 100) <= 8)
                {
                    SpawnPowerupAtB(freeSpot);
                }
            }
        }

        
    }

    void SpawnPowerupAtA(int pos)
    {
        Object.Instantiate(powerupPool[Random.Range(0, powerupPool.Length)], SpawnPointsA[pos].position, referenceObject.transform.rotation);  //OUT OF RANGE EXCEPTION ???????????????????????????
        Debug.Log("at " + pos);
    }

    void SpawnPowerupAtB(int pos)
    {
        Object.Instantiate(powerupPool[Random.Range(0, powerupPool.Length)], SpawnPointsB[pos].position, referenceObject.transform.rotation);
    }

    public void Pause()
    {
        paused = true;
    }

    public void Resume()
    {
        paused = false;
    }
}

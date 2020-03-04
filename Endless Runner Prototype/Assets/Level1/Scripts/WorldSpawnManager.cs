using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WorldSpawnManager : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    [Space]
    public int groundLength;
    [Range(1,10)]public int seeAhead = 1;
    public int alreadyPresent = 1;
    public Transform player;
    public Transform REFGround;

    [Header("Boss Tiles Setup")]
    public GameObject bossStartTile;
    public GameObject[] bossTilesPool;


    private float lastSpawnedAtPos = 0;
    private float start = 0;
    

    void Start()
    {
        lastSpawnedAtPos = alreadyPresent * groundLength;
        SelectRandomGround();
    }

    
    void Update()
    {
        float playerX = player.position.x;

        if (playerX - start >= groundLength)
        {

            //Debug.Log("Check");
            start += groundLength;

            for (int i = 0; i < seeAhead; i++)
            {
                SpawnGround();
                lastSpawnedAtPos += groundLength;
            }
        }
    }

    private void SpawnGround()
    {
        //Debug.Log("Spawn");

        if (GetComponent<BossManager>().BossMode == true)
        {
            SpawnBossGround();
            return;
        }
        else
        {

            var spawn = SelectRandomGround();

            while (spawn == lastSpawned)
            {
                spawn = SelectRandomGround();
            }

            GameObject spawned = Object.Instantiate(spawn, new Vector3(lastSpawnedAtPos, 0, 0), REFGround.rotation);

            lastSpawned = spawn;

            if (GetComponent<BossManager>().BossMode == true)     //CODE TO MANAGE OBSTACLE SPAWNING DURING BOSS 
            {
                spawned.GetComponent<ObstacleSpawner>().Pause();
            }
            else
            {
                spawned.GetComponent<ObstacleSpawner>().Resume();
            }
        }

    }

    private GameObject lastSpawned = null;
    private GameObject SelectRandomGround()
    {
        GameObject _ground;
        _ground = groundPrefabs[Random.Range(0, groundPrefabs.Length)];
        //Debug.Log(_ground.name);
        return _ground;
    }

    private int spawnedBossTiles = 0;
    private void SpawnBossGround()
    {
        if (spawnedBossTiles == 0)
        {
            GameObject spawned = Object.Instantiate(bossStartTile, new Vector3(lastSpawnedAtPos, 0, 0), REFGround.rotation);
            spawnedBossTiles++;
        }
        else
        {
            GameObject spawned = Object.Instantiate(bossTilesPool[Random.Range(0,bossTilesPool.Length)], new Vector3(lastSpawnedAtPos, 0, 0), REFGround.rotation);
        }


    }
}

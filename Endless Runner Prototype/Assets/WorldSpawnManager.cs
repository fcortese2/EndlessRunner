using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawnManager : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    [Space]
    public int groundLength;
    [Range(1,10)]public int seeAhead = 1;
    public int alreadyPresent = 1;
    public Transform player;
    public Transform REFGround;

    private float lastSpawnedAtPos = 0;
    private float start = 0;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnedAtPos = alreadyPresent * groundLength;
        SelectRandomGround();
    }

    // Update is called once per frame
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
        Object.Instantiate(SelectRandomGround(), new Vector3(lastSpawnedAtPos, 0, 0), REFGround.rotation);
    }

    private GameObject SelectRandomGround()
    {
        GameObject _ground;
        _ground = groundPrefabs[Random.Range(0, groundPrefabs.Length)];
        //Debug.Log(_ground.name);
        return _ground;
    }
}

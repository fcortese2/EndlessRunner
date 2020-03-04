using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [Range(.1f,3f)]public float changeLanesEvery;
    public Rigidbody player;
    public Vector3 xDistanceFromPlayer;
    public float clickInterval;
    [Space]
    public GameObject[] bulletPrefabs;
    public Transform shootPoint;
    public int shootChance;

    [SerializeField] private bool bossON = false;
    private bool started = false;
    public bool BossON { get { return BossON; } set { bossON = value; } }

    private void Start()
    {
        foreach (Transform child in GameObject.FindGameObjectWithTag("Boss").transform)
        {
            if (child.GetComponent<MeshRenderer>())
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
    void Update()
    {
        if (bossON && !started)
        {
            InvokeRepeating("LaneAI", 1f, changeLanesEvery);
            started = true;
        }
        
    }

    private void LateUpdate()
    {
        playerDistance();
    }

    private void playerDistance()
    {
        this.transform.position = new Vector3(player.transform.position.x + xDistanceFromPlayer.x, transform.position.y, transform.position.z);
    }

   /* IEnumerator LaneAI()
    {
        yield return new WaitForSeconds()
    }*/

    private void LaneAI()
    {
        //Debug.Log("AI");
        float currentZ = transform.position.z;
        if (currentZ == 2)
        {
            MoveLeft();
        }
        else if (currentZ == 0)
        {
            if (Random.Range(0, 100) <= 50)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }
        else if (currentZ == -2)
        {
            MoveRight();
        }

        ShootAI();
    }

    private void ShootAI()
    {
        if (Random.Range(0,100) < shootChance)
        {
            GameObject bullet = Object.Instantiate(bulletPrefabs[Random.Range(0, bulletPrefabs.Length)], shootPoint.position, shootPoint.rotation);
        }
        else { return; }
    }

    private void MoveRight()
    {
        transform.position += new Vector3(0, 0, clickInterval);
        //Debug.Log("Right");
    }

    private void MoveLeft()
    {
        transform.position += new Vector3(0, 0, -clickInterval);
        //Debug.Log("Left");
    }
}

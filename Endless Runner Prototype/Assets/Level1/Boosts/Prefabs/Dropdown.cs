using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown : MonoBehaviour
{
    [HideInInspector]
    public int arrayIdx = 0;
    
    //public string[] Type = new string[] { "Jump", "Godlike", "Coin x2" };
    public bool jumpBoost = false;
    public bool godlike = false;
    public bool coinBoost = false;

    private void Update()
    {
        if (jumpBoost)
        {
            JumpBoost();
        }
        else if (godlike)
        {
            Godlike();
        }
        else if (coinBoost)
        {
            CoinBoost();
        }
    }

    [Header("Setup")]
    private GameObject player;
    private GameObject gm;
    public float actionRange;
    public float coinEffectDuration;
    public float JumpStrength;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindGameObjectWithTag("GM");
        originalMass = player.GetComponent<Rigidbody>().mass;
    }

    private void CoinBoost()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= actionRange)
        {
            gm.GetComponent<GM_MANAGER>().doubleCoin = true;
            Invoke("returnNormal", coinEffectDuration);
        }
    }

    void returnNormal()
    {
        gm.GetComponent<GM_MANAGER>().doubleCoin = false;
    }

    Transform explosionRef;
    public GameObject missile;
    public Vector3 missileOffset;
    bool used = false;
    private void Godlike()
    {
        if ((Vector3.Distance(transform.position, player.transform.position) <= actionRange) && !used)
        {
            explosionRef = GameObject.FindGameObjectWithTag("ExpRef").transform;
            GameObject _missile = Object.Instantiate(missile, new Vector3(player.transform.position.x, 0, 0) + missileOffset, missile.transform.rotation);
            used = true;
            Object.Destroy(this.gameObject);
        }

    }

    float originalMass;
    private void JumpBoost()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= actionRange)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Jump");
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpStrength * Time.deltaTime, ForceMode.Impulse);
            //Debug.Log("Jump");
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, actionRange);
    }

}

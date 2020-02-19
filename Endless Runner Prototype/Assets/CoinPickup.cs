using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private GameObject GM;
    private Transform player;
    public float pickupSensitivity;
    public float YPosShift;

    private GM_MANAGER manager;
    private Vector3 offset;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GM = GameObject.FindGameObjectWithTag("GM").gameObject;
        manager = GM.GetComponent<GM_MANAGER>();
        offset = new Vector3(0, YPosShift, 0);
    }

    void Update()
    {
        /*foreach (var pickupPoint in playerPickupPoints)
        {
            if (Vector3.Distance(this.transform.position + offset, pickupPoint.position) <= pickupSensitivity)
            {
                manager.AddCoin();
                Object.Destroy(this.gameObject);
            }
        }*/
        if (Vector3.Distance(this.transform.position+offset, player.position) <= pickupSensitivity)
        {
            manager.AddCoin();
            Object.Destroy(this.gameObject);
        }

        if (Vector3.Distance(this.transform.position, player.position) > 150f )
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position + new Vector3(0,YPosShift,0), pickupSensitivity);
    }
}

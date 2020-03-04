using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayerFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset = new Vector3(0, 3, -5);
    private float newPosition;

    //private void Start()
    //{
    //    transform.position = GetNewPosition();
    //}

    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, GetNewPosition(), Time.deltaTime);
        var position = new Vector3(Player.position.x - 4.5f, Player.position.y + 2.4f, transform.position.z);
        transform.position = Vector3.Lerp(position, new Vector3(transform.position.x , transform.position.y , Player.position.z), 15 * Time.deltaTime);
    }

    //private Vector3 GetNewPosition()
    //{
    //    return Player.position + Offset;
    //}


}

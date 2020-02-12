using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayerFollow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x - 4.75f, player.position.y + 3.8f, 0);
    }
}

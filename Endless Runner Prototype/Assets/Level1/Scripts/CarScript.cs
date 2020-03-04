using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float killAfterMin;
    public float killAfterMax;

    public void Start()
    {
        if (killAfterMin > killAfterMax)
        {
            killAfterMax = killAfterMin;
        }
    }
    public void SelfDestroy()
    {
        Invoke("Countdown", Random.Range((float)killAfterMin, (float)killAfterMax));
    }

    public void Countdown()
    {
        Object.Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Kill");
        Object.Destroy(other.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    
    void FixedUpdate()
    {
        //transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + GameObject.FindGameObjectWithTag("Player").transform.forward * 80;
        transform.position = Vector3.Lerp(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position + GameObject.FindGameObjectWithTag("Player").transform.forward * 80, 4f * Time.deltaTime);
        transform.LookAt(Camera.main.transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float changeSpeed;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, (transform.position - Vector3.right), changeSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We've hit something");
        if (collision.transform.tag == "Player")
        {
            //Remove player Health Here and remove pause
            Time.timeScale = 0.001f;
        }
    }
}

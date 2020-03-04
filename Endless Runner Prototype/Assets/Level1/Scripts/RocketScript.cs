using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    List<Rigidbody> blowupList = new List<Rigidbody>();
    public float explosionRange;
    private GameObject player;
    private Transform explosionRef;
    public ParticleSystem explosionEff;
    public float explosionStrength;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
            blowupList.Clear();
            foreach (GameObject element in GameObject.FindGameObjectsWithTag("Obstacle"))
            {
                if (Vector3.Distance(new Vector3(this.transform.position.x, 0, 0), element.transform.position) <= explosionRange)
                {
                    blowupList.Add(element.GetComponent<Rigidbody>());
                }
            }

            explosionRef = GameObject.FindGameObjectWithTag("ExpRef").transform;

            var explosion = Object.Instantiate(explosionEff, new Vector3(this.transform.position.x, 0, 0), explosionRef.rotation);


            for (int i = 0; i < blowupList.Count; i++)
            {
                //blowupElements[i].freezeRotation = false;
                blowupList[i].constraints = RigidbodyConstraints.None;

                blowupList[i].AddExplosionForce(explosionStrength, new Vector3(this.transform.position.x, 0, 0), explosionRange);

                blowupList[i].useGravity = true;

                blowupList[i].GetComponent<CarScript>().SelfDestroy();
            }

        Object.Destroy(this.gameObject);
    }
}

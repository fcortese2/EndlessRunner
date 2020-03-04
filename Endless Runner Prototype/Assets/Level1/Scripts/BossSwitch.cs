using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossSwitch : MonoBehaviour
{
    private GameObject player;
    public float speed;

    [Header("Ref")]
    public CinemachineVirtualCamera vCam;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (Transform child in Camera.main.transform)
        {
            if (child.GetComponent<CinemachineVirtualCamera>())
            {
                vCam = child.GetComponent<CinemachineVirtualCamera>();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().ChangeSpeed(speed);

            foreach (Transform child in player.transform)
            {
                if (child.name == "BossTransform")
                {
                    child.GetComponent<MeshRenderer>().enabled = true;
                    player.GetComponent<MeshRenderer>().enabled = false;
                    player.GetComponent<BoxCollider>().enabled = false;
                    child.GetComponent<BoxCollider>().enabled = true;
                    //vCam.GetComponent<CinemachineFramingTransposer>(). += new Vector3(0, 20, 0);
                }
            }

            //GameObject.FindGameObjectWithTag("Boss").SetActive(true);
            foreach (Transform child in GameObject.FindGameObjectWithTag("Boss").transform)
            {
                if (child.GetComponent<MeshRenderer>())
                {
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAI>().BossON = true;

        }
    }



}

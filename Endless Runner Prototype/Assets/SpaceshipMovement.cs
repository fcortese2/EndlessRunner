using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float thrustPower;
    public float degreeOfTurn;

    bool thrustForward = false;
    bool right, left, up, down;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            thrustForward = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            thrustForward = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            right = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            up = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            up = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            down = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            down = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void FixedUpdate()
    {
        if (thrustForward)
        {
            this.GetComponent<Rigidbody>().AddForce(transform.forward * thrustPower * 10 * Time.deltaTime);
        }

        RotateModel();
    }

    void RotateModel()
    {
        if (right)
        {
            //transform.Rotate(new Vector3(0,0,-5), degreeOfTurn * Time.deltaTime, Space.Self);
            GetComponent<Rigidbody>().AddForce(transform.right * thrustPower * 5 * Time.deltaTime);
        }
        else if (left)
        {
            //transform.Rotate(new Vector3(0, 0, 5), degreeOfTurn * Time.deltaTime, Space.Self);
            GetComponent<Rigidbody>().AddForce(-transform.right * thrustPower * 5 * Time.deltaTime);
        }

        if (up)
        {
            transform.Rotate(new Vector3(5, 0, 0), degreeOfTurn * Time.deltaTime, Space.Self);
        }
        else if (down)
        {
            transform.Rotate(new Vector3(-5, 0, 0), degreeOfTurn * Time.deltaTime, Space.Self);
        }
    }
}

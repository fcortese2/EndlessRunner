using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpStrength;
    public float jumpRayLength;
    public float LeftRowZ, RightRowZ, centerZ;
    public float ClickInterval;

    public Rigidbody rb;

    private bool jump, moveLeft, moveRight = false;
    private float currentZPos;

    private float startSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        currentZPos = centerZ;
        startSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        rb.transform.Translate(new Vector3(1, 0, 0) * speed/5 * Time.deltaTime);

        //WORKS BUT IS BROKEN DUE TO COLLIDERS NOT MATCHING UP
        /*if (rb.velocity.sqrMagnitude != speed*speed)                
        {
            rb.velocity = (Vector3.right.normalized + rb.velocity.normalized) * speed * 6 * Time.deltaTime;
        }*/
        



        if (jump)
        {
            //Debug.Log("Jump");
            rb.AddForce(Vector3.up * jumpStrength * 100 * Time.deltaTime, ForceMode.Impulse);
            jump = false;
        }

        if (moveLeft)
        {
            if (currentZPos == centerZ || currentZPos == RightRowZ)
            {
                rb.transform.position += new Vector3(0, 0, ClickInterval);
                moveLeft = false;
                currentZPos = currentZPos + 2;
            }
            else moveLeft = false;
        }

        if (moveRight)
        {
            if (currentZPos == centerZ || currentZPos == LeftRowZ)
            {
                rb.transform.position += new Vector3(0, 0, -ClickInterval);
                moveRight = false;
                currentZPos = currentZPos - 2;
            }
            else moveRight = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && CanJump())
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight = true;
        }
    }

    private bool CanJump()
    {
        /*RaycastHit hit;
        Physics.Raycast(rb.transform.position, -Vector3.up, out hit, jumpRayLength);
        if (Vector3.Distance(rb.transform.position, hit.point) <= jumpRayLength )
        {
            Debug.Log("Jump");
            return true;
        }
        else return false;*/
        if (rb.transform.position.y <= .05)
        {
            return true;
        }
        else return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(rb.transform.position, -Vector3.up * jumpRayLength);
    }

    public void ChangeSpeed(float value)
    {
        speed = value;
    }

    public void ResetSpeed()
    {
        speed = startSpeed;
    }
}

using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    private float forwardSpeed = 1000f;
    private float lateralSpeed = 4000f;
    private float rotateSpeed = 25.1f;
    private float driftSpeed = 80f;
    private float minAngle = 0f;
    private float maxAngle = 75f;
    private float xRotation = 0f;
    private float zRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        setSpeed();
        UnityEngine.Debug.Log(forwardSpeed);
        rb.AddForce(0, 0, Time.deltaTime * forwardSpeed);
        playerMovement();
    }

    private void playerMovement()
    {
        if (Input.GetKey("a") && forwardSpeed != 0)
        {
            rb.AddForce(Time.deltaTime * -lateralSpeed, 0, 0);
            transform.Rotate(new Vector3(1.5f, 1.5f, 1.5f) * -rotateSpeed * Time.deltaTime);
            rb.AddForce(0, 0, Time.deltaTime * driftSpeed);
        }
        if (Input.GetKey("d") && forwardSpeed != 0)
        {
            rb.AddForce(Time.deltaTime * lateralSpeed, 0, 0);
            transform.Rotate(new Vector3(1.5f, 1.5f, 1.5f) * rotateSpeed * Time.deltaTime);
            rb.AddForce(0, 0, Time.deltaTime * driftSpeed);
        }
      
    }

    private void setSpeed()
    {
        if (Input.GetKeyDown("w") && forwardSpeed < 4000f) // go faster
        {
            forwardSpeed += 500f;
        }
        else if (Input.GetKey("s") && forwardSpeed >= 1000f) // go slower
        {
            forwardSpeed -= 1000f;
        }
        else if (Input.GetKeyDown("s") && Input.GetKey("y") && forwardSpeed <= 0 && forwardSpeed >= -1000f)
        {
            forwardSpeed -= 500f;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "FinishLine")
        {
            UnityEngine.Debug.Log("Finish!");
            rb.AddForce(0, 6400f, 0);
        }
    }
}





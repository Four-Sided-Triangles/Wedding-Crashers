using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxForwardSpeed;
    public float maxBackwardSpeed;
    public float currentSpeed;
    private Rigidbody rb;
    private float forwardSpeed = 0f;
    private float lateralSpeed = 4000f;
    private float rotateSpeed = 25.1f;
    private float driftSpeed = 80f;
    private float minAngle = -75f;
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
        if (currentSpeed < maxBackwardSpeed && currentSpeed > maxBackwardSpeed)
            rb.AddRelativeForce(-transform.up * Time.deltaTime * currentSpeed);
        playerMovement();
    }

    private void playerMovement()
    {
        if (Input.GetKey("a") && forwardSpeed != 0)
        {
            rb.AddForce(Time.deltaTime * -lateralSpeed, 0, 0);
            transform.Rotate(new Vector3(0, 0, 1.0f) * -rotateSpeed * Time.deltaTime);
            rb.AddForce(0, 0, Time.deltaTime * driftSpeed);
        }
        if (Input.GetKey("d") && forwardSpeed != 0)
        {
            rb.AddForce(Time.deltaTime * lateralSpeed, 0, 0);
            transform.Rotate(new Vector3(0, 0, 1.0f) * rotateSpeed * Time.deltaTime);
            rb.AddForce(0, 0, Time.deltaTime * driftSpeed);
        }

    }

    private void setSpeed()
    {
        if (Input.GetKey("w") && currentSpeed < 1200f) // go faster
        {
            currentSpeed += 10f;
        }
        else if (Input.GetKey("s") && currentSpeed > -1000f ) // go slower
        {
            currentSpeed -= 100f;
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "FinishLine")
        {
            UnityEngine.Debug.Log("Finish!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}





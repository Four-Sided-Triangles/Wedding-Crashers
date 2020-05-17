using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxForwardSpeed;
    public float maxBackwardSpeed;
    public float currentSpeed;
    public float push;
    private Rigidbody rb;
    public float rotateSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        setSpeed();
        if (currentSpeed <= maxForwardSpeed && currentSpeed >= maxBackwardSpeed)
        {
            rb.AddForce(transform.forward * currentSpeed * 1000);
            //rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * currentSpeed);
        }

        if (rb.velocity.magnitude > maxForwardSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxForwardSpeed;
            rb.velocity = rb.velocity.normalized * 50;
        }
        playerMovement();
    }

    private void playerMovement()
    {
        if (Input.GetKey("a") && currentSpeed != 0)
        {
            transform.Rotate(new Vector3(0, 1, 0) * -rotateSpeed * currentSpeed/50 * Time.deltaTime);
        }
        if (Input.GetKey("d") && currentSpeed != 0)
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * currentSpeed/50 * Time.deltaTime);
        }

    }

    private void setSpeed()
    {
        if (Input.GetKey("w") && currentSpeed < maxForwardSpeed) // go faster
        {
            currentSpeed += push;
        }
        else if (Input.GetKey("s") && currentSpeed > maxBackwardSpeed) // go slower
        {
            currentSpeed -= push;
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





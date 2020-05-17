using System;
using System.Diagnostics;
using UnityEngine;

public class BasicCar : MonoBehaviour
{

    private Rigidbody rb;
    public float forwardSpeed;
    public float maxSpeed;
    public bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void Update()
    {
        if (isHit == false)
        {
            transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        }
    }
    void FixedUpdate()
    {
        //if (isHit == false)
        //    rb.MovePosition(transform.position + -transform.up * Time.fixedDeltaTime * forwardSpeed);
        setSpeed();
        playerMovement();
    }

    private void playerMovement()
    {

    }

    private void setSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        if (isHit == false)
        {
            rb.AddForce(-transform.up * forwardSpeed);
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BasicCar"))
        {
            isHit = true;
        }
    }
}

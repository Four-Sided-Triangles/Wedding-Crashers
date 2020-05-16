using System;
using System.Diagnostics;
using UnityEngine;

public class BasicCar : MonoBehaviour
{

    private Rigidbody rb;
    private float forwardSpeed = 1000f;
    private float lateralSpeed = 2000f;

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

    }

    private void setSpeed()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

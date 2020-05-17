using System;
using System.Diagnostics;
using UnityEngine;

public class BasicCar : MonoBehaviour
{

    private Rigidbody rb;
    public float forwardSpeed;

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
        if(gameObject.transform.rotation.eulerAngles.z == 0)
        {
            rb.AddForce(-transform.up * Time.deltaTime * forwardSpeed);
        }

        if(gameObject.transform.rotation.eulerAngles.z == 180)
        {
            rb.AddForce(transform.up * Time.deltaTime * -forwardSpeed);
        }
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

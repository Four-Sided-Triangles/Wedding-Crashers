using System;
using System.Diagnostics;
using UnityEngine;

public class BasicCar : MonoBehaviour
{

    private Rigidbody rb;
    public float forwardSpeed;
    public float maxSpeed;
    public bool isHit = false;
    public Vector3 previousPosition;
    const float toleranceForDeletingStoppedObjects = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DestroyIfIdle", 3f, .1f);
        InvokeRepeating("DestroyIfFlying", .01f, .001f);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void DestroyIfIdle()
    {
        if(gameObject.transform.position.x < previousPosition.x + toleranceForDeletingStoppedObjects
            && gameObject.transform.position.y < previousPosition.y + toleranceForDeletingStoppedObjects
            && gameObject.transform.position.z < previousPosition.z + toleranceForDeletingStoppedObjects)
        {
            Destroy(gameObject);
        }

        previousPosition = gameObject.transform.position;
    }

    private void DestroyIfFlying()
    {
        if (gameObject.transform.position.x > 30f || gameObject.transform.position.x < -30f
            || gameObject.transform.position.y > 30f || gameObject.transform.position.y < -4f)
        {
            Destroy(gameObject);
        }
    }

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

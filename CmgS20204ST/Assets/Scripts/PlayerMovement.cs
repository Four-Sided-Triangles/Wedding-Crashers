using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    private float forwardSpeed = 1000f;
    private float lateralSpeed = 2000f;

    private void setRb()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        setRb();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, Time.deltaTime * forwardSpeed);
        playerMovement();
        setSpeed();
    }

    private void playerMovement()
    {
        if (Input.GetKey("a"))
        {
            rb.AddForce(Time.deltaTime * -lateralSpeed, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(Time.deltaTime * lateralSpeed, 0, 0);
        }
    }

    private void setSpeed()
    {
        if (Input.GetKey("w") && forwardSpeed < 4000f)
        {
            forwardSpeed += 500f;
        }
        else if (Input.GetKey("s") && forwardSpeed > 0)
        {
            forwardSpeed -= 500f;
        }
    }
}

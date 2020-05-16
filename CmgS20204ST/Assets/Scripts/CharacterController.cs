using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardSpeed = 2000f;
    public float lateralSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, Time.deltaTime * forwardSpeed);
        playerMovement();
    }

    void playerMovement()
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
}

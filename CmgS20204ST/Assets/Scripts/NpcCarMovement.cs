using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCarMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public Rigidbody rb;
    public Vector2 movement;
    public float forwardSpeed = 100f;
    public float lateralSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, Time.deltaTime * forwardSpeed);
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, Time.deltaTime * forwardSpeed);
    }


}

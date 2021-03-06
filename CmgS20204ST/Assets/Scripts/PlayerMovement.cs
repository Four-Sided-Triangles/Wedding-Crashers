﻿using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float maxForwardSpeed;
    public float maxBackwardSpeed;
    public float currentSpeed;
    public float push;
    private Rigidbody rb;
    public float rotateSpeed = 100.0f;
    private Quaternion originalRotation;

    public AudioSource source;
    public AudioClip lampCollision;
    public AudioClip[] carCollisionSounds;
    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = gameObject.transform.rotation;
    }
    private void Update()
    {
        Reorientate();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        setSpeed();
        if (currentSpeed <= maxForwardSpeed && currentSpeed >= maxBackwardSpeed)
        {
            rb.AddForce(transform.forward * currentSpeed * 1300);
            //rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * currentSpeed);
        }

        if (rb.velocity.magnitude > maxForwardSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxForwardSpeed;
            rb.velocity = rb.velocity.normalized * 50;
        }
        playerMovement();
    }

    private void Reorientate()
    {
        Vector3 pos = gameObject.transform.position;
        Quaternion rot = gameObject.transform.rotation;
        if (pos.x > 40f || pos.x < -40f
            || pos.y > 30f || pos.y < -10f
            || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0,0,0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            gameObject.transform.rotation = originalRotation;
            gameObject.transform.position =
                new Vector3(2f, 2f, pos.z - (pos.z > 0 ? 20f : 0));
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Lamp")
        {
            source.PlayOneShot(lampCollision);
        }
        else if (collision.collider.tag == "Enemy")
        {
            source.PlayOneShot(carCollisionSounds[rnd.Next(0, carCollisionSounds.Length)]);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "FinishLine")
        {
            Destroy(collider.gameObject);
            Invoke("endGame", 0.6f);
        }
    }

    public void endGame()
    {
        UnityEngine.Debug.Log("Finish!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 120f;
    private GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decrement", 2f, 1f); // Arguments: method name, call this method at x time, call this method every y time
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void decrement()
    {
        if (timer == 0)
        {
            Debug.Log("Game Over!");

        }
        timer--;
    }

}

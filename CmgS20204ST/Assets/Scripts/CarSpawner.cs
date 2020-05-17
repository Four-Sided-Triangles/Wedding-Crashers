using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject basicCar;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 3f); // Arguments: method name, call this method at x time, call this method every y time
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(basicCar, gameObject.transform.position, Quaternion.identity);
    }
}

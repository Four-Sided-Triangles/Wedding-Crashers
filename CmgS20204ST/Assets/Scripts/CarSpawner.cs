using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject classicCar;
    public GameObject familyCar;
    public GameObject iceCreamTruck;
    public GameObject sportsCar;
    public GameObject truck;

    public float spawnCoolDown;
    public bool canExpire;
    public float expire;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int) Time.time);
        InvokeRepeating("DestroyIfExpired", 1f, 1f);
    }

    void DestroyIfExpired()
    {
        if (canExpire && expire < 0)
        {
            Destroy(gameObject);
        }
        expire--;
    }

    // Update is called once per frame
    void Update()
    {     
        if (spawnCoolDown <= 0)
        {
            Invoke("Spawn", 0f);
            spawnCoolDown = Random.Range(180f, 500f);
        }
        else
        {
            spawnCoolDown--;
        }

    }

    void Spawn()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        int ran = (int) Random.Range(0, 4);
        GameObject selectedCar = familyCar;
        switch (ran)
        {
            case 0:
                selectedCar = classicCar;
                break;
            case 1:
                selectedCar = familyCar;
                break;
            case 2:
                selectedCar = iceCreamTruck;
                break;
            case 3:
                selectedCar = sportsCar;
                break;
            case 4:
                selectedCar = truck;
                break;
        }
        if (gameObject.CompareTag("Front"))
            Instantiate(selectedCar, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
        else if (gameObject.CompareTag("Reverse"))
            Instantiate(selectedCar, gameObject.transform.position, Quaternion.Euler(-90, 0, 180));
    }
}

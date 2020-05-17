using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 60f;
    private GameObject player;
    public TMPro.TextMeshProUGUI timerText;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decrement", 2f, 1f); // Arguments: method name, call this method at x time, call this method every y time
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time left: " + timer;
    }

    void decrement()
    {
        if (timer == 0)
        {
            SceneManager.LoadScene(3);
        }

        if (timer == 21 || timer <= 21)
        {
            timerText.color = Color.red;
        }
        timer--;
    }

}

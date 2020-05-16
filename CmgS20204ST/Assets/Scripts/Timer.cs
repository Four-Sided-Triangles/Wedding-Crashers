using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 120f;
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
        string minutes = ((int)timer / 60).ToString("00");
        string seconds = ((int)timer % 60).ToString("00");

        if (minutes.Equals("0"))
        {
            timerText.text = "Time left: " + seconds;
        }
        else 
        {
            timerText.text = "Time left: " + minutes.ToString() + ":" + seconds;
        }
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

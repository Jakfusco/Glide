using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timer = 0;
    public float minutes = 0;
    public float seconds = 0;
    public float milliseconds = 0;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTimer();
    }

    void DisplayTimer()
    {
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        milliseconds = (timer % 1) * 1000;

        timeText.text = string.Format("Time: {0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}

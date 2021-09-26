using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public float score = 0;
    public float displayScore = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }

    void DisplayScore()
    {
        score += Time.deltaTime * 10;
        displayScore = Mathf.FloorToInt(score * 100);

        scoreText.text = string.Format("Score: {0:00}", displayScore);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishPoint : MonoBehaviour
{
    public int ScoreP1;
    public int ScoreP2;
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    public TMP_Text S1;
    public TMP_Text S2;
    public TMP_Text Timer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.GetChild(5).tag == "Food")
            {
                Destroy(other.transform.GetChild(5).gameObject);
                ScoreP2 += 1;
                S2.text = ScoreP2.ToString();
            }
        } else if (other.tag == "player2")
        {
            if (other.transform.GetChild(5).tag == "Food")
            {
                Destroy(other.transform.GetChild(5).gameObject);
                ScoreP1 += 1;
                S1.text = ScoreP1.ToString();
            }

        }

    }

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


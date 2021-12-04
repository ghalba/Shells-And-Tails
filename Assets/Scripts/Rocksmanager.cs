using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rocksmanager : MonoBehaviour
{
    public List<GameObject> Rocks;
    public float timeRemaining = 150;
    public bool timerIsRunning = false;
    public float timeToDestroy = 6;
    public TMP_Text Timer;
    public int Nbr=23;
    public int x;

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
        if (timeToDestroy > 0)
        {
            timeToDestroy = timeToDestroy - Time.deltaTime;
        }
        else
        {
            x=Random.Range(0, Nbr);
            Nbr--;
            StartCoroutine(DestroyRock());
        }
            
        
    }
    IEnumerator DestroyRock()
    {
        StartCoroutine(Shake());
        timeToDestroy = 6;
        Destroy(Rocks[x].gameObject);
        Rocks.Remove(Rocks[x]);
        yield return new WaitForSeconds(4f);
        
    }
    IEnumerator Shake()
    {
        Rocks[x].GetComponent<Shake>()._shake = true;
        yield return new WaitForSeconds(2f);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

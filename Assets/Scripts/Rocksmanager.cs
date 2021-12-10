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
            StartCoroutine(Shake(3f));
            StartCoroutine(DestroyRock());
        }
            
        
    }
    IEnumerator DestroyRock()
    {

        timeToDestroy = 6;
        
        yield return new WaitForSeconds(4f);
        Rocks[x].gameObject.SetActive(false);
        Rocks.Remove(Rocks[x]);
    }
    IEnumerator Shake(float t)
    {
        Debug.Log(Rocks[x].name);
        Rocks[x].GetComponent<Shake>()._shake = true;
        yield return new WaitForSeconds(t);
    }
    

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

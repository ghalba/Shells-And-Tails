using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayScore : MonoBehaviour
{
    public GameObject[] Coins;
    private int n;
    public string Winer;
    private void Update()
    {
        n=transform.GetChild(0).GetComponent<Score>()._score;
        
        if (n > 0) { Coins[n - 1].gameObject.SetActive(true); }
        /*if (n >= 3)
        {
            Winer = gameObject.name;
            PlayerPrefs.SetString("Winer", Winer); PlayerPrefs.Save();
            Debug.Log("End");
            Time.timeScale = 0;
        }*/
    }


}

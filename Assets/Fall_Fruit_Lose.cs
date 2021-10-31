using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Fruit_Lose : MonoBehaviour
{
    GameObject P1;
    GameObject P2;
    private void Start()
    {
        P1 = GameObject.FindGameObjectWithTag("player2").gameObject;
        P2 = GameObject.FindGameObjectWithTag("Player").gameObject;

    }
    private void Update()
    {
        if (P1.transform.position.y < -40)
        {
            PlayerPrefs.SetString("Winer", "P2"); PlayerPrefs.Save();
            Debug.Log("End");
            Time.timeScale = 0;
        }
        if (P2.transform.position.y < -40)
        {
            PlayerPrefs.SetString("Winer", "P1"); PlayerPrefs.Save();
            Debug.Log("End");
            Time.timeScale = 0;
        }
    }
}

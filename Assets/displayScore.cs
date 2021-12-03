using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayScore : MonoBehaviour
{
    public GameObject[] Coins;
    private int n1;
    private int n2;
    GameObject P1;
    GameObject P2;
    public bool player1;
    public string Winer;
    private void Start()
    {
        P1 = GameObject.FindGameObjectWithTag("player2").gameObject;
        P2 = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    private void Update()
    {
        n1=P1.GetComponent<Score>()._score;
        n2= P2.GetComponent<Score>()._score;
        if (n1 > 0&&player1) { Coins[n1 - 1].gameObject.SetActive(true); }
        if (n2 > 0&&!player1) { Coins[n2 - 1].gameObject.SetActive(true); }
        if (n1 >= 3)
        {
            MapSelection.p2CanSelect = true;
            MapSelection.ShowUi = true;
            Time.timeScale = 0;
        }else if (n2 >= 3)
        {
            MapSelection.p1CanSelect = true;
            MapSelection.ShowUi = true;
            Time.timeScale = 0;
        }
    }


}

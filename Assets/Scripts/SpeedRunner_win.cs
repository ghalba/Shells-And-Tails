using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRunner_win : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MapSelection.p2CanSelect = other.tag == "player2";
        MapSelection.p1CanSelect = other.tag == "Player";
        MapSelection.p1wins=(other.tag == "player2"? MapSelection.p1wins+1: MapSelection.p1wins);
        MapSelection.p2wins = (other.tag == "Player" ? MapSelection.p2wins + 1 : MapSelection.p2wins);
        MapSelection.ShowUi = true;
        Time.timeScale = 0;
    }
}

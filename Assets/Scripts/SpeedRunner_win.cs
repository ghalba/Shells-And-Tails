using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRunner_win : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MapSelection.p1CanSelect = other.tag == "player2";
        MapSelection.p2CanSelect = other.tag == "Player";
        MapSelection.ShowUi = true;
        Time.timeScale = 0;
    }
}

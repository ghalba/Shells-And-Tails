using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFall_win : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -2f)
        {
            MapSelection.p1CanSelect = gameObject.tag == "player2";
            MapSelection.p2CanSelect = gameObject.tag == "Player";
            MapSelection.p1wins = (gameObject.tag == "Player" ? MapSelection.p1wins + 1 : MapSelection.p1wins);
            MapSelection.p2wins = (gameObject.tag == "player2" ? MapSelection.p2wins + 1 : MapSelection.p2wins);
            MapSelection.ShowUi = true;
            Time.timeScale = 0;
            Destroy(this);
        }
    }
}

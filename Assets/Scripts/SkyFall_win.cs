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
            MapSelection.ShowUi = true;
            Time.timeScale = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFall_win : MonoBehaviour
{
    public Canvas canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player2")
        {
            canvas.gameObject.SetActive(false);
            MapSelection.p1CanSelect = true;
            MapSelection.p2wins++;
            MapSelection.ShowUi = true;
            Time.timeScale = 0;
            Destroy(this);
        }
        if (other.tag == "Player")
        {
            canvas.gameObject.SetActive(false);
            MapSelection.p2CanSelect = true;
            MapSelection.p1wins++;
            MapSelection.ShowUi = true;
            Time.timeScale = 0;
            Destroy(this);
        }
    }
}

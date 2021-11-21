using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public int ScoreP1;
    public int ScoreP2;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.GetChild(5).tag == "Food");
        if ((other.tag == "Player")&&(other.transform.GetChild(5).tag=="Food"))
        {
            GameObject temp = transform.GetChild(5).gameObject;
            temp.transform.SetParent(null);
            Destroy(temp);
            ScoreP1 += 1;
        }else if ((other.tag == "player2") && (other.transform.GetChild(5).tag == "Food"))
        {
            GameObject temp = transform.GetChild(5).gameObject;
            temp.transform.SetParent(null);
            Destroy(temp);
            ScoreP2 += 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public int ScoreP1;
    public int ScoreP2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.transform.GetChild(5).tag == "Food")
            {
                Debug.Log("majdi");
                //transform.GetChild(5).GetComponent<Food>()._delivered = true;
                Destroy(transform.GetChild(5).gameObject);
                ScoreP1 += 1;
            }
        }else if (other.tag == "player2")
            {
            if(other.transform.GetChild(5).tag == "Food")
            {
                Debug.Log("majdi2");
                Destroy(transform.GetChild(5).gameObject);
                ScoreP2 += 1;
            }

        }
    }
}

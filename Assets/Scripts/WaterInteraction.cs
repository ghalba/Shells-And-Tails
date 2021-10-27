using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInteraction : MonoBehaviour
{
    public Transform Spot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name+"ena bhim");
            other.gameObject.transform.position=transform.GetChild(0).position;        
        }
    }

}

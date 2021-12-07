using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Rabbit" || other.gameObject.name == "Turtle")
        {
            if(other.transform.childCount>5)
                if (other.transform.GetChild(5).tag == "Food")
                {
                     Destroy(other.transform.GetChild(5).gameObject);
                }
                
        }
    }
}

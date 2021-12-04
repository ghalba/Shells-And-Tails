using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Rabbit" || other.gameObject.name == "Turtle")
        {
            Destroy(other.transform.GetChild(5).gameObject);
        }
    }
}

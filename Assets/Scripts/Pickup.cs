using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void Update()
    {
        gameObject.GetComponent<PlayerController>().maximumSpeed = 5f;
        if (transform.GetChild(5).tag == "food")
        {
            gameObject.GetComponent<PlayerController>().maximumSpeed = 2f;
        }
    }
}

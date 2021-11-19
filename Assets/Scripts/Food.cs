using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool _delivered;
    public bool _selected;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag== "FP")
        {
            Debug.Log("delivered");
            _delivered = true;
        }
    }
}

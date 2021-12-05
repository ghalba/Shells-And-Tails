using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointT : MonoBehaviour
{
    public Transform _Spot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Rabbit" || other.gameObject.name == "Turtle")
        {
            other.GetComponent<Respawn>().lastCheckPoint = _Spot;
        }
    }

}

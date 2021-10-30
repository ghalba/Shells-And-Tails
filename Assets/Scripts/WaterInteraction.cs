using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInteraction : MonoBehaviour
{
    public Transform Spot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Rabbit")
        {
            other.GetComponent<CharacterController>().gameObject.SetActive(false);
            other.gameObject.transform.position=transform.GetChild(0).position;
            other.GetComponent<CharacterController>().gameObject.SetActive(true);
        }
    }

}

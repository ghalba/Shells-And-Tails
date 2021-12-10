using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Rabbit" || other.gameObject.name == "Turtle")
        {
            other.GetComponent<CharacterController>().gameObject.SetActive(false);
            other.gameObject.transform.position = other.GetComponent<PlayerController>().LastCheckPoint.position;
            other.GetComponent<CharacterController>().gameObject.SetActive(true);
        }
    }

}

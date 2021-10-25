using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public GameObject obej;

    // Use this for initialization
    private void OnTriggerStay(Collider other)
    {
        obej.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        obej.SetActive(true);
    }
}

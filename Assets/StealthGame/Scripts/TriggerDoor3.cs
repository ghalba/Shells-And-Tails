using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor3 : MonoBehaviour
{

    public Animator anim;
    public GameObject ui;

    private void OnTriggerStay(Collider other)
    {
        ui.SetActive(true);
        if (Input.GetKeyDown("e"))
        {
            anim.Play("Dooranim3");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ui.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    public GameObject UI;
    public Animator anim;


    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown("e"))
        {
            UI.SetActive(true);
            anim.Play("Credits");
        }
        
    }
    
}

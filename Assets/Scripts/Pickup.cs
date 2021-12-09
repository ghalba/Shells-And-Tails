using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool CanPickUp = true;
    private void Update()
    {    
        if (transform.childCount > 5)
        {
            if(transform.childCount ==6)
                gameObject.GetComponent<PlayerController>().maximumSpeed = 5f;
            if (transform.childCount == 7)
                gameObject.GetComponent<PlayerController>().maximumSpeed = 4f;
            if (transform.childCount == 8)
                gameObject.GetComponent<PlayerController>().maximumSpeed = 3f;
        }
        else
        {
            gameObject.GetComponent<PlayerController>().maximumSpeed = 6f;
        }
        CanPickUp = (transform.childCount > 7?false:true);
    }
}

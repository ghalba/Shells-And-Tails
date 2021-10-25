using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggertest : MonoBehaviour {

    public GameObject moveplatform;

    private void OnTriggerStay(Collider cube)
    {
        moveplatform.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(moveplatform);
    }

}
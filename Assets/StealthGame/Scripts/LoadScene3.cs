using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene3 : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e"))
        {
            SceneManager.LoadScene("Level 3");
        }
    }


}

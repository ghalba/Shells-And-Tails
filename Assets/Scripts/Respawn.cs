using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool _respawn=false;
    public Transform lastCheckPoint;

    private void Update()
    {
        if (_respawn)
        {
            gameObject.GetComponent<CharacterController>().gameObject.SetActive(false);
            gameObject.gameObject.transform.position = lastCheckPoint.position;
            gameObject.GetComponent<CharacterController>().gameObject.SetActive(true);
            _respawn = false;
        }
        if (transform.position.y < -6)
        {
            _respawn = true;
        }
    }
}

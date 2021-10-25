using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int _score=-1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Debug.Log("coin");
            Destroy(other.gameObject);
            _score++;
        }
    }
}

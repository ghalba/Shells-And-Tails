using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int _score=-1;
    public AudioSource _coinSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            _coinSound.Play();
            Debug.Log("coin");
            Destroy(other.gameObject);
            _score++;
        }
    }
}

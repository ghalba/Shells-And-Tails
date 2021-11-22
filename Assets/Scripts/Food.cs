using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool _delivered;
    public bool _selected;

    private void Update()
    {
        if (_delivered)
        {
            Destroy(gameObject);
        }
    }

}

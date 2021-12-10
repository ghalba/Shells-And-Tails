using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    Vector3 startingPos;
    public float speed = 6f;
    public float amount = 2f;
    public bool _shake = false;
    void Awake()
    {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
    }

    // Update is called once per frame
    public void Update()
    {
        if (_shake)
        {
            gameObject.transform.position = new Vector3(startingPos.x + Mathf.Sin(Time.time * speed) * amount, transform.position.y, transform.position.z);

        }
    }

}

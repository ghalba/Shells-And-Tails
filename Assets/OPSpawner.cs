using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPSpawner : MonoBehaviour
{
    public GameObject obPrefab;
    private GameObject ob;
    public bool Spawn;
    private void Update()
    {
        if (Spawn)
        {

            StartCoroutine(Timer(Random.Range(3f,7f)));
        }
            
    }

    IEnumerator Timer(float x)
    {
        Spawn = false;
        yield return new WaitForSeconds(x);
        ob = Instantiate(obPrefab, transform.position, transform.rotation);
        Destroy(ob, 8f);
        Spawn = true;
    }
}

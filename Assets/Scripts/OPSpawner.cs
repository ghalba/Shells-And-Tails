using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPSpawner : MonoBehaviour
{
    public GameObject[] obPrefabs;
    private GameObject ob;
    public int i;
    public float j;
    public bool Spawn;
    private void Update()
    {
        if (Spawn)
        {
            j = (FinishPoint.spawnRate == 2 ? 4f: 2f);
            StartCoroutine(Timer(Random.Range(1f,j)));
        }
            
    }

    IEnumerator Timer(float x)
    {
        Spawn = false;
        yield return new WaitForSeconds(x);
        i = Random.Range(0,4);
        ob = Instantiate(obPrefabs[i], transform.position, transform.rotation);
        Destroy(ob, 8f);
        Spawn = true;
    }
}

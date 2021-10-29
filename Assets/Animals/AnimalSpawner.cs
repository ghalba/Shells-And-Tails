using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bear;
    public GameObject wolf;
    public GameObject fox;
    public GameObject deer;
    public GameObject raccoon;
    int MaxSpawn = 0;
    int bearcount= 0;

    void spawn()
    {
        int min = 0;
        int max = 10;
        int x;

        x = Random.Range(min, max);
        if (x == 1 && MaxSpawn<10) {
            Instantiate(bear, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            bearcount++;
            MaxSpawn++;
            StartCoroutine(SpawnTime());
        }


    }

    private void Update()
    {
        spawn();
    }

    IEnumerator SpawnTime() {
        yield return new WaitForSeconds(1);

    }
}

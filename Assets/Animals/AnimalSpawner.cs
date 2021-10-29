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
    public GameObject tiger;
    int MaxSpawn = 0;
    int bearcount= 0;
    int wolfcount = 0;
    int deercount = 0;
    int raccooncount = 0;
    int foxcount = 0;
    int tigercount = 0;
    void Spawn1()
    {
        // Stage 1
        int min = 0;
        int max = 10;
        int x;
        x = Random.Range(min, max);
        if (x == 1 && MaxSpawn<10) {
            Instantiate(bear, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            bearcount++;
            MaxSpawn++;
        }
        if (x == 2 && MaxSpawn < 10)
        {
            Instantiate(wolf, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            wolfcount++;
            MaxSpawn++;
        }
        if (x == 3 && MaxSpawn < 10)
        {
            Instantiate(deer, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            deercount++;
            MaxSpawn++;
        }
    }


    void Spawn2()
    {
        // Stage 2
        int min = 0;
        int max = 10;
        int x;
        x = Random.Range(min, max);
        if (x == 1 && MaxSpawn < 15)
        {
            Instantiate(bear, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            bearcount++;
            MaxSpawn++;
        }
        if (x == 2 && MaxSpawn < 15)
        {
            Instantiate(wolf, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            wolfcount++;
            MaxSpawn++;
        }
        if (x == 3 && MaxSpawn < 15)
        {
            Instantiate(deer, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            deercount++;
            MaxSpawn++;
        }
        if (x == 4 && MaxSpawn < 15)
        {
            Instantiate(raccoon, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            raccooncount++;
            MaxSpawn++;
        }
        if (x == 5 && MaxSpawn < 15)
        {
            Instantiate(fox, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            foxcount++;
            MaxSpawn++;
        }
        if (x == 6 && MaxSpawn < 15)
        {
            Instantiate(tiger, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            tigercount++;
            MaxSpawn++;
        }
    }



    private void Update()
    {
        StartCoroutine(SpawnTime());

    }

    IEnumerator SpawnTime() {

        yield return new WaitForSeconds(2);
        Spawn1();

    }
}

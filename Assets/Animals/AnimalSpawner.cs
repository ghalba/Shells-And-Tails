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
    int MaxSpawn2 = 20;
    int bearcount= 0;
    int wolfcount = 0;
    int deercount = 0;
    int raccooncount = 0;
    int foxcount = 0;
    int tigercount = 0;
    public bool _Spawn1;
    public bool _Spawn2;
    //public List<> 
    private void Start()
    {
        _Spawn1 = true;
    }
    private void Update()
    {
        // Stage 1
        if (MaxSpawn < 10 && _Spawn1)
        {
            StartCoroutine(Timer1(1f));
            
        }

        if (MaxSpawn == 10&& _Spawn1)
        {
            MaxSpawn = 0;
            bearcount = 0;
            wolfcount = 0;
            deercount = 0;
            raccooncount = 0;
            foxcount = 0;
            tigercount = 0;
            _Spawn1 = false;
            _Spawn2 = true;
            MaxSpawn2 = 0;
        }
        // Q&A 1

        // Stage 2
        if (MaxSpawn2 < 15 && _Spawn2)
        {
            _Spawn2 = true;
            Debug.Log("Stage 2");
            StartCoroutine(Timer2(1f));
        }
            
        if (MaxSpawn == 15&& _Spawn2)
        {
            MaxSpawn = 0;
            bearcount = 0;
            wolfcount = 0;
            deercount = 0;
            raccooncount = 0;
            foxcount = 0;
            tigercount = 0;
            MaxSpawn = 0;
        }
        // Q&A 2
    }



    IEnumerator Timer1(float t)
    {
        _Spawn1 = false;
        int min = 0;
        int max = 3;
        int x;
        x = Random.Range(min, max);
        if (x == 1 )
        {
            Instantiate(bear, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            bearcount++;
            MaxSpawn++;
        }
        if (x == 2 )
        {
            Instantiate(wolf, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            wolfcount++;
            MaxSpawn++;
        }
        if (x == 3 )
        {
            Instantiate(deer, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            deercount++;
            MaxSpawn++;
        }
        yield return new WaitForSeconds(t);
        _Spawn1 = true;
    }
    IEnumerator Timer2(float t)
    {
        _Spawn2 = false;
        int min = 0;
        int max = 10;
        int x;
        x = Random.Range(min, max);
        if (x == 1 && MaxSpawn2< 15)
        {
            Instantiate(bear, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            bearcount++;
            MaxSpawn2++;
        }
        if (x == 2 && MaxSpawn2 < 15)
        {
            Instantiate(wolf, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            wolfcount++;
            MaxSpawn2++;
        }
        if (x == 3 && MaxSpawn2 < 15)
        {
            Instantiate(deer, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            deercount++;
            MaxSpawn2++;
        }
        if (x == 4 && MaxSpawn2 < 15)
        {
            Instantiate(raccoon, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            raccooncount++;
            MaxSpawn2++;
        }
        if (x == 5 && MaxSpawn2 < 15)
        {
            Instantiate(fox, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            foxcount++;
            MaxSpawn2++;
        }
        if (x == 6 && MaxSpawn2 < 15)
        {
            _Spawn2 = false;
            Instantiate(tiger, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            tigercount++;
            MaxSpawn2++;
            
        }
        yield return new WaitForSeconds(t);
        _Spawn2 = true;
    }
}

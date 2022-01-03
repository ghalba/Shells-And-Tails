using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockrandomizer : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;

    

    public void Start()
    {

        randomizer();

    }
    public void randomizer()
    {
        int x = Random.Range(0, 3);
        Debug.Log(x);
        if (x == 0)
        {
            Instantiate(rock1, pos1.position, Quaternion.Euler(0, -90, 0));
            Instantiate(rock2, pos2.position, Quaternion.Euler(0, -90, 0));
            Instantiate(rock3, pos3.position, Quaternion.Euler(0, 90, 0));

        }
        if (x == 1)
        {
            Instantiate(rock1, pos3.position, Quaternion.Euler(0, -90, 0));
            Instantiate(rock2, pos1.position, Quaternion.Euler(0, -90, 0));
            Instantiate(rock3, pos2.position, Quaternion.Euler(0, 90, 0));

        }
        if (x == 2)
        {
            Instantiate(rock1, pos2.position, Quaternion.Euler(0, -90, 0));
            Instantiate(rock2, pos3.position, Quaternion.Euler(0, -90, 0));
            Instantiate(rock3, pos1.position, Quaternion.Euler(0, 90, 0));

        }
    }
}

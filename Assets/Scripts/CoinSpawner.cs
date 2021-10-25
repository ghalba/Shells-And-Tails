using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject _coin;

    List<Vector3> spawned;
    public Transform parentSlots;

    void Start()
    {
        spawned = new List<Vector3>(0);
        for (int i = 0; i < 5; i++)
            SpawnCoin();
    }

    void SpawnCoin()
    {
        int x = 0;
        if (spawned.Count > 0)
        {
            while (spawned.Contains(parentSlots.GetChild(x).position))
            {
                x = Random.Range(0, parentSlots.transform.childCount);
            }
        }
        else x = Random.Range(0, parentSlots.transform.childCount);


        Instantiate(_coin, parentSlots.GetChild(x).position, Quaternion.identity);
        spawned.Add(parentSlots.GetChild(x).position);
    }
}

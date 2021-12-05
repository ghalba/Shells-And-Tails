using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] FoodPrefab;
    private GameObject _food;
    private void Start()
    {
        _food=Instantiate(FoodPrefab[0], transform.GetChild(0).position, Quaternion.identity);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player2")
        {
            Debug.Log(other.name);
            if (_food.GetComponent<Food>()._selected==false) {
                _food.transform.position = other.transform.GetChild(0).position;
                _food.transform.rotation = other.transform.GetChild(0).rotation;

                _food.transform.SetParent(other.transform);
                _food.GetComponent<Food>()._selected = true;
                StartCoroutine(Timer(6f));
                
            }

        }
        if (other.tag == "Player")
        {
            Debug.Log(other.name);
            if (_food.GetComponent<Food>()._selected==false)
            {
                _food.transform.position = other.transform.GetChild(0).position;
                _food.transform.rotation = other.transform.GetChild(0).rotation;

                _food.transform.SetParent(other.transform);
                _food.GetComponent<Food>()._selected = true;
                StartCoroutine(Timer(6f));
                
            }
        }

    }
    IEnumerator Timer(float x)
    {
        yield return new WaitForSeconds(x);
        int i = Random.Range(0,3);
        _food = Instantiate(FoodPrefab[i], transform.GetChild(0).position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject FoodPrefab;
    private GameObject _food;
    private void Start()
    {
        _food=Instantiate(FoodPrefab, transform.GetChild(0).position, Quaternion.identity);
        
    }

    private void Update()
    {
        
        if (_food.GetComponent<Food>()._delivered)
        {
            _food.transform.position = transform.GetChild(0).position;
            _food.transform.rotation = transform.GetChild(0).rotation;
            _food.transform.SetParent(transform.GetChild(0));
            _food.GetComponent<Food>()._selected = false;
            _food.GetComponent<Food>()._delivered = false;
        }
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
            }
        }

    }
}

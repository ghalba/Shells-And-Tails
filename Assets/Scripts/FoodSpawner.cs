using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject _finishPoint;
    public List<Transform> transforms;
    public List<GameObject> Food;

    private void Update()
    {
        if (Food[0].GetComponent<Food>()._delivered)
        {
            Food[0].transform.position = transforms[0].position;
            Food[0].transform.rotation = transforms[0].rotation;
            Food[0].transform.SetParent(transforms[0]);
            Food[0].GetComponent<Food>()._selected = false;
            Food[0].GetComponent<Food>()._delivered = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player2")
        {
            Debug.Log(other.name);
            if (Food[0].GetComponent<Food>()._selected==false) {
                Food[0].transform.position = other.transform.GetChild(0).position;
                Food[0].transform.rotation = other.transform.GetChild(0).rotation;
                
                Food[0].transform.SetParent(other.transform);
                Food[0].GetComponent<Food>()._selected = true;
            }

        }
        if (other.tag == "Player")
        {
            Debug.Log(other.name);
            if (Food[0].GetComponent<Food>()._selected==false)
            {
                Food[0].transform.position = other.transform.GetChild(0).position;
                Food[0].transform.rotation = other.transform.GetChild(0).rotation;
                
                Food[0].transform.SetParent(other.transform);
                Food[0].GetComponent<Food>()._selected = true;
            }
        }

    }
}

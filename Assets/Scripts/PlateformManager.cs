using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformManager : MonoBehaviour
{
    public GameObject[] plateforms;
    public int Index;
    public int x;
    int screenIndex;

    // Start is called before the first frame update
    void Start()
    {        
        for (int i = 0; i < 12; i++)
        {
            Index = Random.Range(0, 12);
            plateforms[i].transform.GetChild(Index).gameObject.SetActive(true);
            plateforms[i].GetComponent<Platform>().ActiveChildIndex = Index;
        }
        x = Random.Range(0, 12);
        screenIndex = plateforms[x].GetComponent<Platform>().ActiveChildIndex;
        
        StartCoroutine(Display());
        StartCoroutine(Timer());
    }
    IEnumerator Display()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < 12; i++)
        {
            plateforms[i].transform.GetChild(plateforms[i].GetComponent<Platform>().ActiveChildIndex).gameObject.SetActive(false);
            transform.GetChild(screenIndex).gameObject.SetActive(true);
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < 12; i++)
        {
            if(screenIndex!= plateforms[i].GetComponent<Platform>().ActiveChildIndex)
            {
                Destroy(plateforms[i].gameObject);
            }else
                plateforms[i].transform.GetChild(plateforms[i].GetComponent<Platform>().ActiveChildIndex).gameObject.SetActive(true);
        }
          

          
    }

}

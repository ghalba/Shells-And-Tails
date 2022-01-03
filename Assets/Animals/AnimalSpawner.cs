using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnimalSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text QuestionsD;
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject platform;
    public GameObject cam;
    public GameObject bear;
    public GameObject wolf;
    public GameObject fox;
    public GameObject deer;
    public GameObject raccoon;
    public GameObject tiger;
    public List<int> AnimalsCount;
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
    public List<string> Questions;
    public List<string> Questions2;
    Transform temp;
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
            StartCoroutine(Quiz(3f));
            AnimalsCount[0] = 0;
            AnimalsCount[1] = 0;
            AnimalsCount[2] = 0;
            AnimalsCount[3] = 0;
            AnimalsCount[4] = 0;
            AnimalsCount[5] = 0;
            MaxSpawn = 0;
            bearcount = 0;
            wolfcount = 0;
            deercount = 0;
            raccooncount = 0;
            foxcount = 0;
            tigercount = 0;
            _Spawn1 = false;   
        }
        // Q&A 1

        // Stage 2
        if (MaxSpawn2 < 15 && _Spawn2)
        {
            _Spawn2 = true;
            Debug.Log("Stage 2");
            StartCoroutine(Timer2(1f));
        }
            
        if (MaxSpawn2 == 15&& _Spawn2)
        {
            StartCoroutine(Quiz2(3f));
            MaxSpawn = 0;
            bearcount = 0;
            wolfcount = 0;
            deercount = 0;
            raccooncount = 0;
            foxcount = 0;
            tigercount = 0;
            _Spawn2 = false;
            r1.SetActive(true);
            r2.SetActive(true);
            r3.SetActive(true);
            
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
        if (x == 0 )
        {
            Instantiate(bear, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            bearcount++;
            AnimalsCount[0]++;
            MaxSpawn++;
        }
        if (x == 1 )
        {
            Instantiate(wolf, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            wolfcount++;
            AnimalsCount[1]++;
            MaxSpawn++;
        }
        if (x == 2 )
        {
            Instantiate(deer, new Vector3(20, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            deercount++;
            AnimalsCount[2]++;
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
        if (x == 0 && MaxSpawn2< 15)
        {
            Instantiate(bear, new Vector3(5, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            bearcount++;
            AnimalsCount[0]++;
            MaxSpawn2++;
        }
        if (x == 1 && MaxSpawn2 < 15)
        {
            Instantiate(wolf, new Vector3(5, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            wolfcount++;
            AnimalsCount[1]++;
            MaxSpawn2++;
        }
        if (x == 2 && MaxSpawn2 < 15)
        {
            Instantiate(deer, new Vector3(5, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            deercount++;
            AnimalsCount[2]++;
            MaxSpawn2++;
        }
        if (x == 3 && MaxSpawn2 < 15)
        {
            Instantiate(raccoon, new Vector3(5, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            raccooncount++;
            AnimalsCount[3]++;
            MaxSpawn2++;
        }
        if (x == 4 && MaxSpawn2 < 15)
        {
            Instantiate(fox, new Vector3(5, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            foxcount++;
            AnimalsCount[4]++;
            MaxSpawn2++;
        }
        if (x == 5 && MaxSpawn2 < 15)
        {
            _Spawn2 = false;
            Instantiate(tiger, new Vector3(5, 0, Random.Range(45f, 48f)), Quaternion.Euler(0, 90, 0));
            tigercount++;
            AnimalsCount[5]++;
            MaxSpawn2++;
            
        }
        yield return new WaitForSeconds(t);
        _Spawn2 = true;
    }
    IEnumerator Quiz(float t)
    {
        cam.GetComponent<Animator>().SetTrigger("Phase1");
        int x = Random.Range(0, 3);
        int y = Random.Range(0, 3);
        QuestionsD.text = Questions[x];
        r1.transform.GetChild(0).GetComponent<TextMesh>().text = AnimalsCount[x].ToString();
        r2.transform.GetChild(0).GetComponent<TextMesh>().text = (AnimalsCount[x] + 1).ToString();
        r3.transform.GetChild(0).GetComponent<TextMesh>().text = (AnimalsCount[x]-1).ToString();
        Debug.Log(y);
        switch (y)
        {
            case 0:temp.position = r1.transform.position;
                r1.transform.position = r3.transform.position;
                    r3.transform.position = temp.position;
                break;
            case 1:
                temp.position = r1.transform.position;
                r1.transform.position = r2.transform.position;
                r2.transform.position = temp.position;
                break;
        }
        StartCoroutine(QuizA(8f));
        yield return new WaitForSeconds(t);
        
        
        QuestionsD.text = "";
    }
    IEnumerator QuizA(float t)
    {
        //**
        yield return new WaitForSeconds(t);
        //r1.SetActive(false);
        r2.SetActive(false);
        r3.SetActive(false);
        cam.GetComponent<Animator>().SetTrigger("Phase2");
        MaxSpawn2 = 0;
        _Spawn2 = true;
    }
    IEnumerator Quiz2(float t)
    {
        cam.GetComponent<Animator>().SetTrigger("Phase1");
        int x = Random.Range(0, 6);
        int y = Random.Range(0, 3);
        QuestionsD.text = Questions2[x];
        r1.transform.GetChild(0).GetComponent<TextMesh>().text = AnimalsCount[x].ToString();
        r2.transform.GetChild(0).GetComponent<TextMesh>().text = (AnimalsCount[x] + 1).ToString();
        r3.transform.GetChild(0).GetComponent<TextMesh>().text = (AnimalsCount[x] - 1).ToString();
        switch (y)
        {
            case 0:
                temp.position = r1.transform.position;
                r1.transform.position = r3.transform.position;
                r3.transform.position = temp.position;
                break;
            case 1:
                temp.position = r1.transform.position;
                r1.transform.position = r2.transform.position;
                r2.transform.position = temp.position;
                break;
        }
        StartCoroutine(QuizA2(8f));
        yield return new WaitForSeconds(t);

        Debug.Log("test");
        QuestionsD.text = "";
    }
    IEnumerator QuizA2(float t)
    {
        //**
        yield return new WaitForSeconds(t);
        //r1.SetActive(false);
        r2.SetActive(false);
        r3.SetActive(false);
        cam.GetComponent<Animator>().SetTrigger("Phase2");
        MaxSpawn2 = 16;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform[] checkpoints;
    public Transform currentcheckpoint1;
    public Transform currentcheckpoint2;
    GameObject P1;
    GameObject P2;
    int i1 = 0;
    int i2 = 0;
    private void Start()
    {
        currentcheckpoint1 = checkpoints[0];
        currentcheckpoint2 = checkpoints[0];
        P1 = GameObject.FindGameObjectWithTag("player2").gameObject;
        P2 = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    private void Update()
    {
        
        
        if (P1.transform.position.x > checkpoints[i1].position.x)
        {
            currentcheckpoint1 = checkpoints[i1];
            Debug.Log(checkpoints[i1].name);
            i1++;
        }
        if (P1.transform.position.x > checkpoints[i2].position.x)
        {
            currentcheckpoint2 = checkpoints[i2];
            Debug.Log(checkpoints[i2].name);
            i2++;
        }
        if (P1.transform.position.y < -2)
        {
            //Debug.Log("Respawn");
            Respawn("P1");
        }
        if (P2.transform.position.y < -2)
        {
            //Debug.Log("Respawn");
            Respawn("P2");
        }
    }
    public void Respawn(string player)
    {
        if (player == "P1")
            P1.transform.position = currentcheckpoint1.position;
        else if (player == "p2")
            P2.transform.position = currentcheckpoint2.position;
    }
}

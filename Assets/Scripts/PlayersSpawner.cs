using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSpawner : MonoBehaviour
{
    public InputValuesSaver ivsManette;
    public InputValuesSaver ivsClavier;
    public Cinemachine.CinemachineFreeLook Camera1;
    public Cinemachine.CinemachineFreeLook Camera2;
    public Camera camera1;
    public Camera camera2;
    public Transform P1;
    public Transform P2;
    public static PlayersSpawner Instance = null;

    void Start()
    {
        if (Instance == null)
        {
            string character0 = PlayerPrefs.GetString("Character0");
            string character1 = PlayerPrefs.GetString("Character1");
            Debug.Log("Player1 " + character0);
            Debug.Log("Player2 " + character1);
            SpawnSomeone(character0, 0);
            SpawnSomeone(character1, 1);
        }
    }

    void SpawnSomeone(string c, int pNumber)
    {
        GameObject currentFinalPlayer = null;
        if(c == "Turtle")
        {
            Transform focus = (pNumber == 0 ? P1.GetChild(0).GetChild(2) : P2.GetChild(0).GetChild(2));
            if(pNumber == 0)
            {
                Camera1.LookAt = focus;
                Camera1.Follow = focus;
                currentFinalPlayer = P1.GetChild(0).gameObject;
            } else
            {
                Camera2.LookAt = focus;
                Camera2.Follow = focus;
                currentFinalPlayer = P2.GetChild(0).gameObject;
            }
            
            
        } else
        {
            Transform focus = (pNumber == 0 ? P1.GetChild(1).GetChild(3) : P2.GetChild(1).GetChild(3));
            if (pNumber == 0)
            {
                Camera1.LookAt = focus;
                Camera1.Follow = focus;
                currentFinalPlayer = P1.GetChild(1).gameObject;
            }
            else
            {
                Camera2.LookAt = focus;
                Camera2.Follow = focus;
                currentFinalPlayer = P2.GetChild(1).gameObject;
            }
        }
        PlayerController pC = currentFinalPlayer.GetComponent<PlayerController>();
        pC.cameraTransform = (pNumber == 0 ? camera1.transform : camera2.transform);
        pC.movement = (pNumber == 0 ? ivsClavier.movement : ivsManette.movement);
        pC.jump = (pNumber == 0 ? ivsClavier.jump : ivsManette.jump);
        pC.Stealth = (pNumber == 0 ? ivsClavier.Stealth : ivsManette.Stealth);
        P2.GetChild(1).gameObject.SetActive(true);
        currentFinalPlayer.SetActive(true);
        Debug.Log("Spawned " + pNumber);
    }
}

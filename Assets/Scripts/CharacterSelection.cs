using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    private InputAction RL;
    [SerializeField]
    private InputAction _ready;
    private float _RL;
    private int _currentChild;
    public static int n = 0;
    bool isReady = false;

    private void Awake()
    {
        RL.performed += ONRLPreformed;
        RL.canceled += ONRLPreformed;
        _ready.performed += Ready;

        PlayerPrefs.DeleteKey("Character0");
        PlayerPrefs.DeleteKey("Character1");
    }
    private void OnEnable()
    {
        RL.Enable();
        _ready.Enable();
    }
    private void OnDisable()
    {
        RL.Disable();
        _ready.Disable();
    }
    private void ONRLPreformed(InputAction.CallbackContext context)
    {
        _RL = RL.ReadValue<float>();
        if (_RL != 0)
        {
            if (_currentChild == 0)
                _currentChild = 1;
            else
                _currentChild = 0;
            SwitchCharacter(_currentChild);
        }
    }
    void Ready(InputAction.CallbackContext context)
    {
        if (isReady) 
            return;
        Debug.Log("ready");
        int currentPlayer = (transform.name == "P1" ? 0 : 1);
        n++;
        isReady = true;
        string chosenCharacter = "";
        if (currentPlayer == 0)
            chosenCharacter = _currentChild == 0 ? "Turtle" : "Rabbit";
        else chosenCharacter = _currentChild == 0 ? "Rabbit" : "Turtle";

        PlayerPrefs.SetString("Character" + currentPlayer, chosenCharacter); PlayerPrefs.Save();

        if (n == 2)
            AllReady();
    }
    void AllReady()
    {
        Debug.Log("All Ready");
        SceneManager.LoadScene("Treasure_Hunt");
    }

    private void SwitchCharacter(int _CurrentChild)
    {
        if (_CurrentChild == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

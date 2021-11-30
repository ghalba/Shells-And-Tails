using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    
    public static bool p1CanSelect ;
    public static bool p2CanSelect ;
    public int M1;
    public int M2;
    [SerializeField]
    private InputAction RL;
    [SerializeField]
    private InputAction _ready;
    private float _RL;
    [SerializeField]
    private InputAction RL2;
    [SerializeField]
    private InputAction _ready2;
    private float _RL2;


    private void Awake()
    {
        RL.performed += ONRLPreformed;
        RL.canceled += ONRLPreformed;
        _ready.performed += Ready;
        RL2.performed += ONRL2Preformed;
        RL2.canceled += ONRL2Preformed;
        _ready2.performed += Ready2;
    }
    private void OnEnable()
    {
        RL.Enable();
        _ready.Enable();
        RL2.Enable();
        _ready2.Enable();
    }
    private void OnDisable()
    {
        RL.Disable();
        _ready.Disable();
        RL2.Enable();
        _ready2.Enable();
    }
    private void ONRLPreformed(InputAction.CallbackContext context)
    {
        _RL = RL.ReadValue<float>();
        if (p1CanSelect)
        {
            if (_RL == -1)
            {
              
            }
        }

    }
    private void ONRL2Preformed(InputAction.CallbackContext context)
    {
        _RL2 = RL2.ReadValue<float>();
        if (p2CanSelect)
        {
            if (_RL2 != 0)
            {
                Debug.Log("player 2 Rl");
            }
        }

    }
    void Ready(InputAction.CallbackContext context)
    {
        if (p1CanSelect)
        {
            Debug.Log("player 1 Ready");
        }
    }
    void Ready2(InputAction.CallbackContext context)
    {
        if (p2CanSelect)
        {
            Debug.Log("player 2 Ready");
        }
    }
}

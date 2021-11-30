using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    
    public static bool p1CanSelect = true;
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
            if (_RL != 0)
            {

            }
        }

    }
    private void ONRL2Preformed(InputAction.CallbackContext context)
    {
        _RL2 = RL2.ReadValue<float>();
        if (!p1CanSelect)
        {
            if (_RL2 != 0)
            {

            }
        }

    }
    void Ready(InputAction.CallbackContext context)
    {
        if (p1CanSelect)
        {

        }
    }
    void Ready2(InputAction.CallbackContext context)
    {
        if (!p1CanSelect)
        {

        }
    }
}

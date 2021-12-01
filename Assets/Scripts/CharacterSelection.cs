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
    public int _currentChild;
    public static int n = 0;
    bool isReady = false;
    private Animator anim;
    public Camera _cam;
    private Animator _camAnim;
    public Canvas canvas;
    public Canvas canvas2;
    public GameObject Flip;
    public Material _turtuleMaterial;
    public Material _rabbitMaterial;

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
        int currentPlayer = (transform.name == "P1" ? 0 : 1);
        anim = transform.GetChild(_currentChild).GetComponent<Animator>();
        anim.SetTrigger("GettingUp");
        RL.Disable();
        n++;
        isReady = true;
        string chosenCharacter = "";
        if (currentPlayer == 0)
            chosenCharacter = _currentChild == 0 ? "Turtle" : "Rabbit";
        else chosenCharacter = _currentChild == 0 ? "Turtle": "Rabbit";
        PlayerPrefs.SetString("Character" + currentPlayer, chosenCharacter); PlayerPrefs.Save();

        if (n == 2)
            AllReady();
        return;
    }
    void AllReady()
    {
        _camAnim = _cam.GetComponent<Animator>();
        _camAnim.SetTrigger("Ready");
        Debug.Log("All Ready");
        StartCoroutine(Timer2());                    
        
    }
    IEnumerator Timer3()
    {
        yield return new WaitForSeconds(4);
        canvas2.transform.GetChild(0).gameObject.SetActive(true);
    }
    IEnumerator Timer()
    {
        yield return new WaitUntil(() => Flip.GetComponent<coinState>().Flip==true);
        int x = UnityEngine.Random.Range(0,1);
        Flip.GetComponent<MeshRenderer>().material =(x==0? _turtuleMaterial: _rabbitMaterial);
        MapSelection.p1CanSelect = (x == 0 ? true: false);
        MapSelection.p2CanSelect = (x == 0 ? false : true);
        StartCoroutine(Timer3());
    }
    IEnumerator Timer2()
    {
        yield return new WaitForSeconds(3);
        canvas.transform.GetChild(4).gameObject.SetActive(true);
        StartCoroutine(Timer());

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

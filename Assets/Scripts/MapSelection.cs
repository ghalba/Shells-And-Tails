using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    
    public static bool p1CanSelect ;
    public static bool p2CanSelect ;
    public static bool ShowUi;
    public int M;
    public int mapsNb;
    public List<string> MapsName;
    public List<string> completedMaps;
    public Canvas canvas;
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
    public void Start()
    {
        mapsNb = 6;
    }
    
    private void Awake()
    {
       
        RL.performed += ONRLPreformed;
        RL.canceled += ONRLPreformed;
        _ready.performed += Ready;
        RL2.performed += ONRL2Preformed;
        RL2.canceled += ONRL2Preformed;
        _ready2.performed += Ready2;
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;

        RL.Enable();
        _ready.Enable();
        RL2.Enable();
        _ready2.Enable();
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        p1CanSelect = false;
        p2CanSelect = false;
        ShowUi = false;
        Time.timeScale = 1;
        canvas.transform.GetChild(0).gameObject.SetActive(false);
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
                canvas.transform.GetChild(0).GetChild(M).gameObject.SetActive(false);
                M = (M != 0 ? M - 1 : mapsNb);
                canvas.transform.GetChild(0).GetChild(M).gameObject.SetActive(true);
            }else if(_RL == 1)
            {
                canvas.transform.GetChild(0).GetChild(M).gameObject.SetActive(false);
                M = (M != mapsNb ? M + 1 : 0);
                canvas.transform.GetChild(0).GetChild(M).gameObject.SetActive(true);
            }
        }

    }
    private void ONRL2Preformed(InputAction.CallbackContext context)
    {
        _RL2 = RL2.ReadValue<float>();
        if (p2CanSelect)
        {
            if (_RL2 == -1)
            {
                canvas.transform.GetChild(0).GetChild(M).gameObject.SetActive(false);
                M = (M != 0 ? M - 1 : 4);
                canvas.transform.GetChild(0).GetChild(M).gameObject.SetActive(true);
            }
            else if (_RL2 == 1)
            {
                canvas.transform.GetChild(0).GetChild(M).gameObject.SetActive(false);
                M = (M != 4 ? M + 1 : 0);
                canvas.transform.GetChild(0).GetChild(M).gameObject.SetActive(true);
            }
        }

    }
    void Ready(InputAction.CallbackContext context)
    {
        if (p1CanSelect)
        {
            if (completedMaps.Find(x => x == MapsName[M]) != null)
            {
                Debug.Log("you can't choose this map");
               
            }
            else
            {

                SceneManager.LoadScene(MapsName[M]);
                completedMaps.Add(MapsName[M]);
                
            }

        }
    }
    void Ready2(InputAction.CallbackContext context)
    {
        if (p2CanSelect)
        {
            if(completedMaps.Find(x => x == MapsName[M])!=null)
                {
                    Debug.Log("you can't choose this map");
                    
                }
                else
                {
                    
                    SceneManager.LoadScene(MapsName[M]);
                    completedMaps.Add(MapsName[M]);
                    
                }

            
        }
    }

    private void Update()
    {
        if (ShowUi)
        {
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            ShowUi = false;
        }
    }
}

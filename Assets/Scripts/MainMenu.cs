using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    public GameObject _Coin;
    

    public void PlayGame()
    {
       
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Played");


    }
    public void Flip()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("CoinFlip");
        _Coin.GetComponent<Animator>().SetTrigger("Coin");
        _Coin.GetComponent<coinState>().Flip = true;
       
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}


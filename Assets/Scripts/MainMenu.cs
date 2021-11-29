using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator anim;
    public GameObject _Coin;


    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Played");


    }
    public void Flip()
    {
        _Coin.GetComponent<Animator>().SetTrigger("Coin");
        _Coin.GetComponent<coinState>().Flip = true;
        transform.GetChild(4).gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}


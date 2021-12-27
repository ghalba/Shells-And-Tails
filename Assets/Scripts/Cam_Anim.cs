using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cam_Anim : MonoBehaviour
{
    public Animator anim;
    public GameObject _Coin;
    public PlayableDirector playableDirector;
    public GameObject P1;
    public GameObject P2;
    public void OnPlay()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Played");
        playableDirector.Play();      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playableDirector.time = 80f;
        }
        if(playableDirector.time > 76f)
        {
            P1.SetActive(true);
            P2.SetActive(true);
        }
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

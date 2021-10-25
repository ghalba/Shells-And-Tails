using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour {

    public GameObject gameLoseUI;
    public GameObject gameWinUI;
    bool gameisover;

	
	void Start () {
        Guard.onguardspotedPlayer += ShowGameloseUI;
        FindObjectOfType<Player>().onReachendlevel += ShowGamewinUI;
	}
	

	void Update () {
		if (gameisover) {
            if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Level 1");
        }

    }
}

    void ShowGamewinUI() {
        ongameover(gameWinUI);
    }

    void ShowGameloseUI()
    {
        ongameover(gameLoseUI);
    }

    void ongameover(GameObject gameoverUI) {
        gameoverUI.SetActive(true);
        gameisover = true;
        Guard.onguardspotedPlayer -= ShowGameloseUI;
        FindObjectOfType<Player>().onReachendlevel -= ShowGamewinUI;
    }

}

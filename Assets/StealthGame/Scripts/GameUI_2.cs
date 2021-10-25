using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUI_2 : MonoBehaviour {

    public GameObject gameLoseUI2;
    public GameObject gameWinUI2;
    bool gameisover2;

	
	void Start () {
        Guard.onguardspotedPlayer += ShowGameloseUI2;
        FindObjectOfType<Player>().onReachendlevel += ShowGamewinUI2;
	}
	

	void Update () {
		if (gameisover2) {
            if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Level 2");
        }

    }
}

    void ShowGamewinUI2() {
        ongameover2(gameWinUI2);
    }

    void ShowGameloseUI2()
    {
        ongameover2(gameLoseUI2);
    }

    void ongameover2(GameObject gameoverUI) {
        gameoverUI.SetActive(true);
        gameisover2 = true;
        Guard.onguardspotedPlayer -= ShowGameloseUI2;
        FindObjectOfType<Player>().onReachendlevel -= ShowGamewinUI2;
    }

}

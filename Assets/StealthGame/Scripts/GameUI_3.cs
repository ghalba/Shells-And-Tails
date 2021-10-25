using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUI_3 : MonoBehaviour {

    public GameObject gameLoseUI3;
    public GameObject gameWinUI3;
    bool gameisover3;

	
	void Start () {
        Guard.onguardspotedPlayer += ShowGameloseUI3;
        FindObjectOfType<Player>().onReachendlevel += ShowGamewinUI3;
	}
	

	void Update () {
		if (gameisover3) {
            if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Level 3");
        }

    }
}

    void ShowGamewinUI3() {
        ongameover3(gameWinUI3);
    }

    void ShowGameloseUI3()
    {
        ongameover3(gameLoseUI3);
    }

    void ongameover3(GameObject gameoverUI) {
        gameoverUI.SetActive(true);
        gameisover3 = true;
        Guard.onguardspotedPlayer -= ShowGameloseUI3;
        FindObjectOfType<Player>().onReachendlevel -= ShowGamewinUI3;
    }

}

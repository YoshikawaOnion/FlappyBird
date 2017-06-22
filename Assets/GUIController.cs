using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {
	private bool isActive;
	public Button button;

	// Use this for initialization
	void Start () {
        button.gameObject.SetActive(false);
        button.onClick.AddListener(Retry);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.Instance.gameState.Value == GameController.GameState.GameOver
			&& !isActive) {
			isActive = true;
            button.gameObject.SetActive(true);
		}
	}

	void Retry(){
		isActive = false;
		button.gameObject.SetActive(false);
        SceneManager.LoadScene("FlappyGame");
		GameController.Instance.gameState.Value = GameController.GameState.Play;
		GameController.Instance.score.Value = 0;
	}
}

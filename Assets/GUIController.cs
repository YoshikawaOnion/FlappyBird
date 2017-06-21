using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		switch (GameController.Instance.gameState.Value) {
		case GameController.GameState.GameOver:
			GUIGameOver ();
			break;
		default:
			break;
		}
	}

	void GUIGameOver(){
		float x = Screen.width * 0.1f;
		float y = Screen.height * 0.6f;
		if (GUI.Button (new Rect(x, y, Screen.width - (x*2), Screen.height * 0.3f), "RETRY")) {
			Application.LoadLevel (Application.loadedLevel);
			GameController.Instance.gameState.Value = GameController.GameState.Play;
			GameController.Instance.score.Value = 0;
		}
	}
}

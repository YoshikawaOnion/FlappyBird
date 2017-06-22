using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour {
	private Text text;
	private IDisposable scoreSubscription;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();

		ChangeScore (GameController.Instance.score.Value);
		scoreSubscription = GameController.Instance.score
			.Subscribe(ChangeScore);
	}

	void OnDestroy () {
		if (GameController.Instance != null) {
			scoreSubscription.Dispose ();
		}
	}

	void ChangeScore(int score){
        text.text = "Score:" + score;
	}
}

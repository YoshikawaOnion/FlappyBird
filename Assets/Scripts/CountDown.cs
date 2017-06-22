using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    public Text countObject;
    private int count;
    private bool isCounting;
    private System.IDisposable countdownDisposable;

	// Use this for initialization
	void Start () {
        count = 3;
        isCounting = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.Instance.gameState.Value == GameController.GameState.Preparing
           && !isCounting)
        {
            countdownDisposable = Observable.IntervalFrame(60)
                      .Take(3)
                      .Subscribe(x =>
            {
                --count;
                countObject.text = count.ToString();
            },
                                 () =>
            {
                GameController.Instance.gameState.Value = GameController.GameState.Play;
                isCounting = false;
                countObject.gameObject.SetActive(false);
			});
			countObject.gameObject.SetActive(true);
            isCounting = true;
        }
    }

    private void OnDestroy()
    {
        countdownDisposable.Dispose();
    }
}

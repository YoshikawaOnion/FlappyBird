using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameController {
	public enum GameState{
		Title, Play, GameOver
	}

	private static GameController instance_;
	public static GameController Instance
	{
		get { return instance_ = instance_ ?? new GameController (); }
	}

	public NotifyProperty<int> score { get; }
	public NotifyProperty<GameState> gameState { get; }

	public GameController ()
	{
		score = new NotifyProperty<int> ();
		gameState = new NotifyProperty<GameState> ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnDestroy(){
		score.Dispose ();
		gameState.Dispose ();
	}
}

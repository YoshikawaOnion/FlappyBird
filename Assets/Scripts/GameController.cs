﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Toolkit;

public class GameController {
	public enum GameState{
		Title, Play, GameOver, Preparing
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
        gameState.Value = GameState.Preparing;
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

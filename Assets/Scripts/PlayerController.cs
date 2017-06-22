using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour {
    private abstract class State{
        protected PlayerController Owner { get; set; }
        public State(PlayerController owner)
        {
            Owner = owner;
        }
        public virtual void Initialize()
        {            
        }
        public virtual void Update()
        {
        }
        public virtual void Transit(GameController.GameState state)
        {
        }
		void FixedUpdate()
		{
		}
		void OnCollisionEnter2D(Collision2D collision)
		{
		}
        void OnDestroy()
        {
        }
		void ChangeGameState(GameController.GameState state)
		{
		}
    }

    private bool isJumpRequest;
	private Rigidbody2D rigidBody;
	private System.IDisposable gameStateSubscription;
    private System.IDisposable kinematicSubscription;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		gameStateSubscription = GameController.Instance.gameState.Subscribe (ChangeGameState);
        kinematicSubscription = GameController.Instance.gameState
                                              .Where(x => x == GameController.GameState.Play)
					                          .Subscribe(x => rigidBody.isKinematic = false);
		rigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.Instance.gameState.Value == GameController.GameState.Preparing)
        {
            return;
        }
        if (Input.GetMouseButtonDown (0)) {
			isJumpRequest = true;
		}
	}

	public float power = 2;

	void FixedUpdate(){
		if (isJumpRequest) {
			isJumpRequest = false;
			rigidBody.velocity = Vector3.up * power;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		GameController.Instance.gameState.Value = GameController.GameState.GameOver;
	}

	void OnDestroy(){
		if (GameController.Instance != null) {
			gameStateSubscription.Dispose ();
            kinematicSubscription.Dispose();
		}
	}

	void ChangeGameState(GameController.GameState state){
		switch (state) {
		case GameController.GameState.GameOver:
			    enabled = false;
			break;
		default:
			break;
		}
	}
}

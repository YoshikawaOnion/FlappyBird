using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoad : MonoBehaviour {
	public float speed = 1;
	private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.Instance.gameState.Value == GameController.GameState.Preparing)
        {
            return;
        }
        rigidbody.velocity = -Vector2.right * speed;
	}
}

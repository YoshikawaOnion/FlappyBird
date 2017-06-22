using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
	public float speed = 1;
	private float current;
	private Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.Instance.gameState.Value == GameController.GameState.Preparing)
        {
            return;
        }
        current += Time.deltaTime * speed;
		renderer.material.SetTextureOffset ("_MainTex", new Vector2(current, 0));
	}
}

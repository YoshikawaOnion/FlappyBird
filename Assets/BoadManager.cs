using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoadManager : MonoBehaviour {
	public GameObject boadObject;
	private float nextSpawnTime = 0;
	private float interval = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (nextSpawnTime < Time.timeSinceLevelLoad) {
			nextSpawnTime = Time.timeSinceLevelLoad + interval;
			LocalInstantiate ();
		}
	}

	void LocalInstantiate(){
		GameObject obj = (GameObject)GameObject.Instantiate (boadObject);
		obj.transform.parent = transform;

		float y = Random.Range (0.5f, -0.3f);
		obj.transform.localPosition = new Vector3 (7, y, 0);
	}

	void OnTriggerExit2D(Collider2D collider) {
		Destroy (collider.attachedRigidbody.gameObject);
	}
}

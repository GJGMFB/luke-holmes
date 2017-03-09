using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public float destroyAtPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > destroyAtPos)
			Destroy (this.gameObject);
	}

	void onCollisionEnter(Collision col) {
		if (col.gameObject.name == "Ball") {
			Debug.Log ("sfsdf");
			Destroy (col.gameObject);
		}
		Debug.Log ("coll");
	}
}

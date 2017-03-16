using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTrigger : MonoBehaviour {
	public Camera cam;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter(Collider c) {
		Debug.Log ("trigger");
		if (c.gameObject.name == "Player") {
			Debug.Log ("player");
			Camera.main.gameObject.SetActive (false);
			cam.gameObject.SetActive (true);
		}
	}



	void OnTriggerExit(Collider c) {
		if (c.gameObject.name == "Player") {
			//cam.enabled = false;
		}
	}
}

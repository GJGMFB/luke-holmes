using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiTrigger : MonoBehaviour {
	public Canvas canvas;
	public float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.name == "Player") {
			canvas.gameObject.SetActive (true);
			Invoke ("fadeOut", time);
		}
	}

	void OnTriggerExit(Collider c) {
	}

	void fadeOut() {
		canvas.gameObject.SetActive (false);
	}
}

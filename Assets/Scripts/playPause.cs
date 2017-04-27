using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playPause : MonoBehaviour {
	public bool isPaused;

	// Use this for initialization
	void Start () {
		if (isPaused) {
			Time.timeScale = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			isPaused = false;
			Time.timeScale = 1;
		}
	}
}

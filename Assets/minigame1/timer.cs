using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	public float timeLimit;
	public GameObject text;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time + timeLimit;
		Invoke ("win", timeLimit);
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime - Time.time >= 0)
			text.GetComponent<Text> ().text = "" + Mathf.FloorToInt(startTime - Time.time);
	}

	void win() {
		Debug.Log ("winner!");
	}
}

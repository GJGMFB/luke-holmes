using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest1 : MonoBehaviour {
	public GameObject gate;
	public GameObject t;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (PlayerPrefs.HasKey ("item1") && PlayerPrefs.GetInt ("item1") == 1) {
		if (globals.Item) {
			var te = t.GetComponent<TextMesh> ();
			te.text = "Thanks for finding the key! Now the gate is open!";
			Destroy (gate);
		}
	}
}

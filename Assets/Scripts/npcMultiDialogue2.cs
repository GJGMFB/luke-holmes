using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class npcMultiDialogue2 : MonoBehaviour {
	public Canvas canvas;
	public string[] dialog;
	private Text textBox;
	private int dialogIndex;

	// Use this for initialization
	void Start () {
		dialogIndex = 0;
		canvas.gameObject.SetActive (false);
		textBox = canvas.GetComponentInChildren<Text> ();

		// Set first line of dialog
		textBox.text = dialog[dialogIndex];
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			// Check if reached last block of dialog
			if ((dialogIndex + 1) == dialog.Length) {
				canvas.gameObject.SetActive (false);
			}
			// Otherwise show next block of dialog
			else {
				textBox.text = dialog [++dialogIndex]; // Display next block of dialog
			}
		}
	}

	void OnTriggerEnter(Collider c) {
		if (c.CompareTag ("Player")) {
			canvas.gameObject.SetActive (true);
		}
	}

	void OnTriggerExit(Collider c) {
		if (c.CompareTag ("Player")) {
			canvas.gameObject.SetActive (false);
		}
	}
}

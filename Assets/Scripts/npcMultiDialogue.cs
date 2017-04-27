using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class npcMultiDialogue : MonoBehaviour {
	public Canvas canvas;
	public string[] dialog;
	private Text textBox;
	private int dialogIndex;

	// Use this for initialization
	void Start () {
		dialogIndex = 0;

		if (gameManager.getTutorial () || SceneManager.GetActiveScene ().name != "levelOne") {
			canvas.gameObject.SetActive (true);
			textBox = canvas.GetComponentInChildren<Text> ();

			// Disable movement
			gameManager.disableMovement();

			// Set first line of dialog
			textBox.text = dialog[dialogIndex];
		} else {
			canvas.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			// Check if reached last block of dialog
			if ((dialogIndex + 1) == dialog.Length) {
				canvas.gameObject.SetActive (false);
				gameManager.hideTutorial (); // Forever hides the game's intro event
				gameManager.enableMovement(); // Allow player movement
			}
			// Otherwise show next block of dialog
			else {
				textBox.text = dialog [++dialogIndex]; // Display next block of dialog
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dialog : MonoBehaviour {
	public GameObject textBox;
	public Text text;
	public string words;
	public string wordsWin;
	public bool miniGame;
	public string sceneName;

	//public AudioClip impact;
	//AudioSource audio;

	private GameObject miniGameText;
	private bool insideTrigger = false;

	// Use this for initialization
	void Start () {
		textBox.SetActive (false);
	//	audio = GetComponent<AudioSource>();

		// Add mini game start text if this NPC starts a mini game
		if (miniGame) {
			//miniGameText = gameObject.transform.Find ("Canvas").gameObject;
			miniGameText = GetComponentInChildren<Canvas> ().gameObject;
			miniGameText.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Check for keypresses if NPC starts a mini game
		if (insideTrigger && miniGame) {
			if (Input.GetKeyDown ("space")) {
				interior0_sceneManager.loadNewScene(sceneName); // Use local scene manager to save some data, then load the minigame
			}
		}
	}

	// Check if player is inside trigger zone
	void OnTriggerEnter(Collider c) {
		if (c.name == "Player") {
			// Set vars
			insideTrigger = true;

			//play sound effect
			//	audio.PlayOneShot(impact, 0.5F);

			// Set and show dialog text, depends on mini game status
			if (gameManager.getMiniGameStatus(sceneName) == 1) {
				text.text = wordsWin;
			} else {
				text.text = words;
			}

			textBox.SetActive (true);

			// Show mini game text
			if (miniGame) {
				miniGameText.transform.LookAt (Camera.main.transform);
				miniGameText.transform.forward *= -1;
				miniGameText.SetActive (true);
			}
		}
	}

	void OnTriggerExit(Collider c) {
		if (c.name == "Player") {
			//Set vars
			insideTrigger = false;

			// Hide dialog box
			textBox.SetActive (false);

			// Hide mini game text
			if (miniGame) {
				miniGameText.SetActive (false);
			}
		}
	}
}

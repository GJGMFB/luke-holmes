using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class showHide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (gameManager.getTutorial () || SceneManager.GetActiveScene().name != "levelOne") {
			show ();
		} else {
			hide ();
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.anyKeyDown) {
//			hide ();
//		}
		if (Input.anyKeyDown) {
			hide ();
			gameManager.hideTutorial ();
		}

	}

	void show(){
		GetComponent<Canvas> ().enabled = true;
	}
	void hide(){
		GetComponent<Canvas> ().enabled = false;
	}
}

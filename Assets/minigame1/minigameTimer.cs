using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class minigameTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("loadScene", 30);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void loadScene() {
		gameManager.loadNewLevel("scene");
	}
}

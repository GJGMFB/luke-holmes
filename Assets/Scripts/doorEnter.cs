using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorEnter : MonoBehaviour {
	public string sceneName;
	public bool rememberLastPosOnLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Load scene if we enter a door trigger
	void OnTriggerEnter(Collider c) {
		if (c.CompareTag("Player")) {
			if (rememberLastPosOnLoad) {
				gameManager.setLastPlayerPos (GameObject.FindWithTag ("Player").transform.position);
				gameManager.unsetLastPlayerPosStatus ();
			}

			gameManager.setLastLevel (SceneManager.GetActiveScene ().name);
			gameManager.loadNewLevel(sceneName);
		}
	}
}

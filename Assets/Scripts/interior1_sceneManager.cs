using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interior1_sceneManager : MonoBehaviour {
	public GameObject blocks;
	public GameObject player;

	// Use this for initialization
	void Start () {
		// Setup the environment
		if (gameManager.getBallBreaker () == 1) {
			blocks.SetActive (false);
		} else {
			blocks.SetActive (true);
		}

		// Set player to correct position
		if (gameManager.getLastPlayerPosStatus ()) {
			player.transform.position = gameManager.getLastPlayerPos ();
			gameManager.unsetLastPlayerPosStatus ();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public static void loadNewScene(string sceneName) {
		gameManager.setLastPlayerPos (GameObject.FindWithTag("Player").transform.position);
		gameManager.setLastLevel (SceneManager.GetActiveScene ().name);
		gameManager.loadNewLevel(sceneName);
	}
}

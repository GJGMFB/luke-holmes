using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour {
	public Transform level2Spawn;

	private string scene;

	void Start() {
		if (gameManager.getLastLevel () == "levelTwo") {
			scene = "levelOne";
			transform.position = level2Spawn.position;
		} else {
			scene = "levelTwo";
		}
	}

    void OnTriggerEnter2D()
    {
        Debug.Log("YOU WIN");

		gameManager.setLastLevel (SceneManager.GetActiveScene ().name);
		gameManager.loadNewLevel(scene);
    }
}

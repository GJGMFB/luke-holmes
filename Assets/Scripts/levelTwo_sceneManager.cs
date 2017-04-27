using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTwo_sceneManager : MonoBehaviour {
	public GameObject player;
	public GameObject mg2Spawn;
	public GameObject bbSpawn;
	public GameObject froggerSpawn;

	// Use this for initialization
	void Start () {
		// Set player position
		if (gameManager.getLastLevel() == "interior0-level2") {
			player.transform.position = mg2Spawn.transform.position;
		}

		if (gameManager.getLastLevel() == "interior1-level2") {
			player.transform.position = bbSpawn.transform.position;
		}

		if (gameManager.getLastLevel() == "frogger") {
			player.transform.position = froggerSpawn.transform.position;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}

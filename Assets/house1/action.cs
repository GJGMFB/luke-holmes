using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class action : MonoBehaviour {
	public GameObject location;
	public GameObject player;
	public bool changeLocation;
	public bool loadScene;
	public string scene;

	private bool isInside;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (isInside) {
			if (changeLocation) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					// Move player outside
					player.transform.position = location.transform.position;
				}
			} else if (loadScene) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					SceneManager.LoadScene (scene);
				}
			}
		}
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.name == "Player") {
			isInside = true;
		}
	}

	void OnTriggerExit(Collider c) {
		if (c.gameObject.name == "Player") {
			isInside = false;
		}
	}
}

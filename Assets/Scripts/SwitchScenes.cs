using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour {
	public string scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			gameManager.loadNewLevel(scene);
		}
	}

	/*void OnTriggerEnter(Collider other){
		SceneManager.LoadScene(scene);
	} */


}

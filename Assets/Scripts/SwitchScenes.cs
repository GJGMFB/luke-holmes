using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			SceneManager.LoadScene ("minigame1");
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			SceneManager.LoadScene("minigame1");
		}
	}
}

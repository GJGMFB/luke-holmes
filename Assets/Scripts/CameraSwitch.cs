using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

	public GameObject main;
	public GameObject npc;
	public static bool camSwitch = false;

	// Use this for initialization
	void Start () {
	//	cam = this.GetComponent<Camera> ();
		main = GameObject.Find("Main Camera");
		npc = GameObject.Find ("NPC Camera");

		main.SetActive (true);
		npc.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	/*if (npcDialogue.clicked == true) {
			main.SetActive (false);
			npc.SetActive (true);
		} else {
			main.SetActive (true);
			npc.SetActive (false);
		}   */
		if (npcDialogue.clicked == true) {
			main.SetActive (true);
			npc.SetActive (false);
			npcDialogue.clicked = false; //set back to false 
		}

	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			main.SetActive (false);
			npc.SetActive (true);
			camSwitch = true;
		}
	}
}

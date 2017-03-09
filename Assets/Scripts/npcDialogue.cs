using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcDialogue : MonoBehaviour {

	//Rigidbody npc;
	public static bool clicked = false;

	// Use this for initialization
	void Start () {
	//	npc = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CameraSwitch.camSwitch == true) {   //camera was switched
			if (Input.GetMouseButtonDown (0)) { //click again to switch back 
				clicked = true;
			}
		}
	}

	/*void OnMouseDown(){
		//when this object is clicked on, switch from main to npc camera
		clicked = true;
		//show npc dialogue

	} */
}

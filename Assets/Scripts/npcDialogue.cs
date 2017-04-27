using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcDialogue : MonoBehaviour {

	public static bool clicked = false;  //used for when camera switches from main to npc
	//public Text npc1Text;
	public GameObject npcText;

	// Use this for initialization
	void Start () {
	//	npc = this.GetComponent<Rigidbody> ();
		npcText = GameObject.FindWithTag("npcText");
		//npc1Text.text = "Luke Holmes! Please help me!!\n Press Space to investigate..." ;
		npcText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (CameraSwitch.camSwitch == true) {   //camera was switched
			npcText.SetActive(true);
			npcText.transform.LookAt (Camera.main.transform);
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

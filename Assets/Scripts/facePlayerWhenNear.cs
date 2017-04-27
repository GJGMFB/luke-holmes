using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use on an NPC to make it face the player when the player approaches it
public class facePlayerWhenNear : MonoBehaviour {
	private Quaternion originalRotation;

	// Use this for initialization
	void Start () {
		originalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider c) {
		if (c.CompareTag("Player")) {
			Vector3 relativePos = c.transform.position - transform.position;
			relativePos.y = 0; // Ignore vertical position
			Quaternion r = Quaternion.LookRotation (relativePos);
			transform.rotation = r;
		}
	}

	void OnTriggerExit(Collider c) {
		if (c.gameObject.CompareTag("Player")) {
			transform.rotation = originalRotation;
		}
	}
}

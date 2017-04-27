using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadCell : MonoBehaviour {

   

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "ball") {
			Destroy (collision.gameObject);
			gameM.instance.LoseLife ();
		}
	}
}

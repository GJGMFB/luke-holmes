using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdf : MonoBehaviour {
	void onCollisionEnter(Collision col) {
		if (col.gameObject.name == "Cylinder") {
			Debug.Log ("sfsdf");
			Destroy (col.gameObject);
		}
		Debug.Log ("coll");
	}
}

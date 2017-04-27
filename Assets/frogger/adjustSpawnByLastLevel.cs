using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustSpawnByLastLevel : MonoBehaviour {
	public Transform level2Spawn;

	// Use this for initialization
	void Start () {
		if (gameManager.getLastLevel() == "levelTwo") {
			transform.position = level2Spawn.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
	public GameObject enemy;
	public float spawnEnemyAfter;
	public float spawnWidth;
	public float spawnHeight;
	public float minSpeed;
	public float maxSpeed;
	public float incSpeedAfter;
	public float destroyAfterPos;
	public GameObject gameOverText;
	public GameObject fade;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnEnemy", 0, spawnEnemyAfter);
		InvokeRepeating ("speedUp", incSpeedAfter, incSpeedAfter);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnEnemy() {
		GameObject instance = Instantiate (enemy);
		instance.name = "enemy";
		var script = instance.GetComponent<enemy>(); // enemy is the name of the script enemy.cs
		script.destroyAtPos = destroyAfterPos;
		script.ui = gameOverText;
		script.fade = fade;

		Rigidbody rb = instance.GetComponent<Rigidbody> ();
		instance.transform.position = new Vector3 (spawnWidth, Random.Range (transform.position.y, transform.position.y + spawnHeight));

		rb.velocity = new Vector3 (Random.Range (minSpeed, maxSpeed), 0);
	}

	void speedUp() {
		minSpeed *= 2;
		maxSpeed *= 2;

		InvokeRepeating ("spawnEnemy", 0, spawnEnemyAfter + 0.1f);
	}
}

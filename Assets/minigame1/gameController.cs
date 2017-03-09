using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
	public GameObject ball;
	private Rigidbody ballRb;

	public float force;
	public float gravityAmount;
	private ConstantForce gravity;

	// Use this for initialization
	void Start () {
		ballRb = ball.GetComponent<Rigidbody> ();
		ballRb.useGravity = false;

		// Add custom gravity
		gravity = ball.AddComponent<ConstantForce> ();
		gravity.force = new Vector3 (0, gravityAmount, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ballRb.velocity = Vector3.zero;
			ballRb.AddForce (Vector3.up * force, ForceMode.Impulse);
			//ballRb.velocity = new Vector3(0, force);
		}
	}
}

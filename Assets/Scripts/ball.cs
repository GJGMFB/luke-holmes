using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    public float ballInitVelocity;
	public float bounceMultiplier; // Is not really a multiplier because it adds an impulse force
	public float maxSpeed;
    private Rigidbody rb;
    private bool ballInPlay;
	private float zLoc;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
		zLoc = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
			//rb.AddForce(new Vector3(ballInitVelocity, ballInitVelocity, 0));
			rb.velocity = new Vector3(ballInitVelocity, ballInitVelocity, 0);
			Debug.Log ("Ball launched with sqr velocity: " + rb.velocity.sqrMagnitude);
        }

		transform.position = new Vector3 (transform.position.x, transform.position.y, zLoc);
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.name == "paddle" || c.gameObject.name == "left wall" || c.gameObject.name == "right wall") {
			if (rb.velocity.sqrMagnitude <= maxSpeed) {
				Debug.Log ("Speed up from " + rb.velocity.sqrMagnitude);
				rb.AddForce (rb.velocity.normalized * bounceMultiplier, ForceMode.Impulse);
			}
		}
	}
}
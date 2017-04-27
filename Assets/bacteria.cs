using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacteria : MonoBehaviour {

    public Rigidbody2D rb;

    public float minSpeed = 8f;
    public float maxSpeed = 12f;

    public float speed = 1f;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);

	}
}

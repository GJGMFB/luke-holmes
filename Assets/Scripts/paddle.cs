using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {

    public float paddleSpeed = 1f;
	public float stageWidth;

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);


	// Update is called once per frame
	void Update () {

        float xPos = transform.position.x + (Input.GetAxis("Mouse X") * paddleSpeed);
		playerPos = new Vector3(Mathf.Clamp(xPos, -stageWidth,stageWidth),-9.5f,0f);
        transform.position = playerPos;
	}
}

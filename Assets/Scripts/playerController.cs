//***************************************************
//Sources:
//http://wiki.unity3d.com/index.php/Click_To_Move_C
//***************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerController : MonoBehaviour {

    private Transform trans;
    private Vector3 destPos; //position of destination
    private float destDist;  //distance to destination
	private float accel;
    public float speed;
	public float scale; // if the player is scaled in size, we have to adjust the values. 1 is for smaller scale, higher numbers are for larger scale

	// Use this for initialization
	void Start () {
        trans = transform;
        destPos = trans.position;
		accel = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		// Move only if enabled
		if (gameManager.checkMovement ()) {
			destDist = Vector3.Distance (destPos, trans.position); 

			if (Input.GetMouseButton (0)) {
				Plane playerPlane = new Plane (Vector3.up, trans.position);
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				float mdist = 0.0f;

				if (playerPlane.Raycast (ray, out mdist)) {
					Vector3 target = ray.GetPoint (mdist);
					destPos = ray.GetPoint (mdist);
					Quaternion targetRotation = Quaternion.LookRotation (target - transform.position);
                
					// Move to mouse if destination is greater than 0.25 units away. Stops extreme jittering.
					if (destDist > 0.25f*scale) {
						// Slow down at 0.8 unit away
						if (destDist < 0.8f*scale) {
							if (accel < speed / 2f) {
								accel = speed / 1.8f; // Give a minimum movement speed
							} else {
								accel -= 0.15f*scale; // Otherwise slow them down
							}
						}
					// Accelerate if further than the slow down point
					else {
							if (accel < speed) {
								accel += 0.15f*scale; // Accelerate if not at max speed
							}
						}
					
						trans.position = Vector3.MoveTowards (trans.position, destPos, accel * Time.deltaTime);
						trans.rotation = targetRotation;
					}
				}
			} else {
				accel = 0f; // Reset acceleration when mouse released
			}
		}
    }
}

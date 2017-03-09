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
    public float speed;
    

	// Use this for initialization
	void Start () {
        trans = transform;
        destPos = trans.position;
	}
	
	// Update is called once per frame
	void Update () {
        destDist = Vector3.Distance(destPos, trans.position); 

        if(destDist < .5f)
        {
            speed = 0;
        }
        else if(destDist > .5f)
        {
            speed = 3;
        }

        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {

            Plane playerPlane = new Plane(Vector3.up, trans.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float mdist = 0.0f;

            if (playerPlane.Raycast(ray, out mdist))
            {
                Vector3 target = ray.GetPoint(mdist);
                destPos = ray.GetPoint(mdist);
                Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
                trans.rotation = targetRotation;
            }
        }
        else if (Input.GetMouseButton(0) && GUIUtility.hotControl == 0)
        {
            Plane playerPlane = new Plane(Vector3.up, trans.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float mdist = 0.0f;

            if (playerPlane.Raycast(ray, out mdist))
            {
                Vector3 target = ray.GetPoint(mdist);
                destPos = ray.GetPoint(mdist);
                Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
                trans.rotation = targetRotation;
            }
        }

        if (destDist > .5f)
        {
            trans.position = Vector3.MoveTowards(trans.position, destPos, speed * Time.deltaTime);
        }
    }
}

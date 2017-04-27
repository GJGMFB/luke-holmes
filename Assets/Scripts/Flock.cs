using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {


    public float speed = 0.1f;
    float rotationSpeed = .01f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    //float neighborDistance = 2.0f;        
        
        
    // Use this for initialization
	void Start () {
        speed = Random.Range(.5f, 1);
	}
	
	// Update is called once per frame
	void Update () {
        if(Random.Range(0,5) < 1)
        {
            func();
        }
        transform.Translate(Time.deltaTime * speed, Time.deltaTime * speed, Time.deltaTime * speed);
	}

    void func()
    {
        GameObject[] goal;
        goal = globalFlock.allCells;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = globalFlock.goalPos;
        float dist;

        int groupSize = 0;
        foreach(GameObject go in goal)
        {
            dist = Vector3.Distance(go.transform.position, this.transform.position);
            if(go != this.gameObject)
            {
                vcentre += go.transform.position;
                groupSize++;

                if(dist < 1.0f)
                {
                    vavoid = vavoid + (this.transform.position - go.transform.position);
                }

                Flock anotherFlock = go.GetComponent<Flock>();
                gSpeed = gSpeed + anotherFlock.speed;

            }
        }

        if(groupSize > 0)
        {
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;

            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed*Time.deltaTime);
            }
        }
    }
}

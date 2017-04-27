using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour {

    public GameObject cellPrefab;
    public static int fieldSize = 1;
    static int numCells = 100;
    public static GameObject[] allCells = new GameObject[numCells];
    public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start () {

        for(int i=0; i < numCells; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-fieldSize, fieldSize) ,
                                      Random.Range(-fieldSize, fieldSize) ,
                                      Random.Range(-fieldSize, fieldSize));
            allCells[i] = (GameObject)Instantiate(cellPrefab, pos, Quaternion.identity);
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-fieldSize, fieldSize),
                                      Random.Range(-fieldSize, fieldSize),
                                      Random.Range(-fieldSize, fieldSize));
        }
		
	}
}

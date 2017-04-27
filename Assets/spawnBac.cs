using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBac : MonoBehaviour {

    public float spawnRate = .3f;
    float nextSpawn = 0f;
    public GameObject bacteria;

    public Transform[] spawnPoints;

	void Start() {
		spawnBacteria();
		spawnBacteria();
		spawnBacteria();
		spawnBacteria();
		spawnBacteria();
		spawnBacteria();
	}

    void Update()
    {

        if(nextSpawn <= Time.time)
        {
            spawnBacteria();
            nextSpawn = Time.time + spawnRate;
        }
    }

    void spawnBacteria()
    {
        int rand = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[rand];
        Instantiate(bacteria, spawnPoint.position, spawnPoint.rotation);
    }
}

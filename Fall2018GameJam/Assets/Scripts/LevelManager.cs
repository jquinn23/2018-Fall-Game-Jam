using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject enemy;
    private GameObject[] spawners;
    public float spawnTime;
	// Use this for initialization
	void Start () {
        spawners = GameObject.FindGameObjectsWithTag("Layer Spawner");
        InvokeRepeating("SpawnEnemy", 0, spawnTime);
	}
	

    void SpawnEnemy()
    {
        int random = Random.Range(0, (int)spawners.Length);
        GameObject.Instantiate(enemy, spawners[random].transform.position - new Vector3(1, 0), new Quaternion(0, 0, 0, 0));
    }

	// Update is called once per frame
	void Update () {
		
	}
}

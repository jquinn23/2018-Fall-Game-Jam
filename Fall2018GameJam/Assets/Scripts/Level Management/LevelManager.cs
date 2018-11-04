using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject enemy;
    private GameObject[] spawners;
    public float[] spawnTime;
    public float waveLength = 30.0f;
    private float timer;
    public int waveNumber;
    private int timePassed;
    private bool nextWave;

    // Use this for initialization
    void Start () {
        spawners = GameObject.FindGameObjectsWithTag("Layer Spawner");
        timer = waveLength;
        timePassed = 0;
        waveNumber = 0;
        InvokeRepeating("SpawnEnemy", 0, spawnTime[waveNumber]);
    }
	

    void SpawnEnemy()
    {
        int random = Random.Range(0, (int)spawners.Length);
        GameObject.Instantiate(enemy, spawners[random].transform.position - new Vector3(1, 0), new Quaternion(0, 0, 0, 0));
    }

    

    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            waveNumber++;
            timer = waveLength;
            nextWave = true;
        }
        if (waveNumber > spawnTime.Length - 1)
        {
            waveNumber = (spawnTime.Length - 1);
        }
        if(nextWave == true)
        {
            nextWave = false;
            CancelInvoke();
            InvokeRepeating("SpawnEnemy", 0, spawnTime[waveNumber]);
        }
    }
}

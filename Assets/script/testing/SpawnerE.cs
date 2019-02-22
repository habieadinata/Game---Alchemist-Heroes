using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerE : MonoBehaviour {

    public GameObject[] ObstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;

    public float minTime = 0.65f;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, ObstaclePatterns.Length);
            Instantiate(ObstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
           
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime; 
        }
    }
}

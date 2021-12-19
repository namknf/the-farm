using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeeds : MonoBehaviour
{
    public GameObject[] weeds;

    float[] spawnPoints = {-4.11f, -5.18f, 0.06f, -0.30f};
    Vector2 spawnPosition;

    public float timeBetweenSpawn;
    public float timeSpawn;

    public int amountOfWeeds = 1;
    
    void Update()
    {
        if(timeBetweenSpawn <= 0)
        {
            float[] cloneSpawnPoint = spawnPoints.OrderBy(i => Random.Range(-5f, 5f)).ToArray();

            for(int i = 0; i < amountOfWeeds; i++)
            {
                int randPos = Random.Range(0, weeds.Length);
                float randomPoints = cloneSpawnPoint[i];
                spawnPosition = new Vector2(transform.position.x, randomPoints);
                Instantiate(weeds[randPos], spawnPosition, Quaternion.identity);
            }
            timeBetweenSpawn = timeSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}

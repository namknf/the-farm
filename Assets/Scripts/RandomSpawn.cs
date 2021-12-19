using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] leaves;

    Vector2 whereToSpawn;
    float RandX;

    private float timeBtwSpawn;
    public float spawnTime;

    public int leavesSpawnAmount = 1;

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {

            for (int i = 0; i < leavesSpawnAmount; i++)
            {
                int rand = Random.Range(0, leaves.Length);

                RandX = Random.Range(-10.0f, 10.0f);

                whereToSpawn = new Vector2(RandX, transform.position.y);

                Instantiate(leaves[rand], whereToSpawn, Quaternion.identity);
            }
            timeBtwSpawn = spawnTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}

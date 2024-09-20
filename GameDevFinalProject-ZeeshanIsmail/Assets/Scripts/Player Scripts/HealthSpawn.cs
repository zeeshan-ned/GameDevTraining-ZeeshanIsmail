using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour
{
    public GameObject HealthOrbPrefab;
    public float spawnRadius = 4f;
    public float spawnFrequency = 5f;
    public float sp;
    public int maxOrbs = 3;

    private int currentOrbs = 0;
    void Start()
    {
        sp = spawnFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentOrbs < maxOrbs)
        {
            if (sp < 0)
            {
                SpawnEnemy();
                currentOrbs++;
            }
            else
            {
                sp -= Time.deltaTime;
            }

        }
    }
    public void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + (Random.insideUnitSphere * spawnRadius);
        spawnPosition.y = 1f;
        Instantiate(HealthOrbPrefab, spawnPosition, Quaternion.identity);
    }
}

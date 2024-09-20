using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 4f;
    public float spawnFrequency = 2f;
    public int maxEnemies = 3;
    public float sp;

    private int currentEnemies = 0;    
    
    void Start()
    {
        sp = spawnFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            if (sp < 0)
            {
                SpawnEnemy();
                currentEnemies++;
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
        spawnPosition.y = 0f;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}

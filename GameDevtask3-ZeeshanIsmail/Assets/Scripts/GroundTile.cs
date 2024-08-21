using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }
    
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        //Choose a random point 
        int obstaclespwanindex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstaclespwanindex).transform;
        //Spawn the obstacle
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity,transform);
    }
}

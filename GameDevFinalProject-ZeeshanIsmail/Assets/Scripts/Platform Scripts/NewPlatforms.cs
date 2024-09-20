using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlatforms : MonoBehaviour
{
    public GameObject planePrefab;// The plane prefab to be instantiated
    public Vector3 CurrentPlanePosition;
    public float SpawnTimer = 10f;
    public float sT;

    private void Start()
    {
        //set timer to the given value
        sT = SpawnTimer;
    }
    public void Update()
    {
        //if Timer is less than zero spawn plane otherwise decrease timer
        if (sT < 0)
        {
            SpawnPlaneAtPoint();
            sT = SpawnTimer;
        }
        else 
        {
            sT -= 1 * Time.deltaTime;
        }
    }
    
    protected int spawnpoint;
    public void SpawnPlaneAtPoint()
    {
        //Select a Random number that corresponds to spawn points around the plane
        spawnpoint = Random.Range(0, 3);

        //if spawnpoint is 0 Spawn Plane North of the current one
        if (spawnpoint == 0)
        {
            Vector3 NewPlaneposition = CurrentPlanePosition + new Vector3(8, 0, 0);
            Instantiate(planePrefab, NewPlaneposition, Quaternion.identity);
            CurrentPlanePosition = NewPlaneposition;
        }
        //if spawnpoint is 1 Spawn Plane South of the current one
        if (spawnpoint == 1)
        {
            Vector3 NewPlaneposition = CurrentPlanePosition + new Vector3(-8, 0, 0);
            Instantiate(planePrefab, NewPlaneposition, Quaternion.identity);
            CurrentPlanePosition = NewPlaneposition;
        }
        //if spawnpoint is 2 Spawn Plane East of the current one
        if (spawnpoint == 2)
        {
            Vector3 NewPlaneposition = CurrentPlanePosition + new Vector3(0, 0, -8);
            Instantiate(planePrefab, NewPlaneposition, Quaternion.identity);
            CurrentPlanePosition = NewPlaneposition;
        }
        //if spawnpoint is 0 Spawn Plane West of the current one
        if (spawnpoint == 3)
        {
            Vector3 NewPlaneposition = CurrentPlanePosition + new Vector3(0, 0, 8);
            Instantiate(planePrefab, NewPlaneposition, Quaternion.identity);
            CurrentPlanePosition = NewPlaneposition;
        }
    }
}



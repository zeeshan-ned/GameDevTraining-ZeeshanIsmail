using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public Transform Player;
    public GameObject BulletPrefab;
    public Transform SpawnPoint;
    public GameObject target;
    public float bulletSpeed;
    public bool enableMobileControls = false;

    public void Update()
    {
        if (enableMobileControls == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnBullet();
            }
        }
    }
    public void SpawnBullet()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Zombie");
        Player.transform.LookAt(enemy.transform.position);
        var bullet = Instantiate(BulletPrefab, SpawnPoint.transform.position, Quaternion.identity);
        
        if (bullet != null)
        {
            Vector3 direction = bullet.transform.position - target.transform.position;
            direction.Normalize();
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(direction.x * bulletSpeed, 0, direction.z * bulletSpeed);
        }
    }
}

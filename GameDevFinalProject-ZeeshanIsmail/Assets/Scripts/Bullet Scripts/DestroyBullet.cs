using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public float Timer;
    // Update is called once per frame
    void Update()
    {
        if (Timer < 0)
        {
            destroyBullet();
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }
    public void destroyBullet()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlane : MonoBehaviour
{
    public float Timer = 15f;
    // Update is called once per frame
    void Update()
    {
        if (Timer < 0)
        {
            destroyPlane();
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }
    public void destroyPlane()
    {
        Destroy(gameObject);
    }
}

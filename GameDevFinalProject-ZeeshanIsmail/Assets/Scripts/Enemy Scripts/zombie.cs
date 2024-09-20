using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    private Transform player;
    public float speed = 5f;
    Rigidbody rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Soldier_demo").transform;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.LookAt(player.transform.position);
        rb.velocity = Vector3.MoveTowards(transform.position, player.position, step) * speed * Time.deltaTime;
        if (rb.velocity.magnitude > 0)
        {
            anim.SetBool("Walking", true);
        }
    }
}

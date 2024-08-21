using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;
    float horizontalInput;
    public float horizontalmultipier = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 ForwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 HorizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalmultipier;
        rb.MovePosition(rb.position + ForwardMove + HorizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}

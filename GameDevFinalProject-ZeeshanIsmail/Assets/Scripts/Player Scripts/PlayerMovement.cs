using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
            
    public float JumpForce;
    public float MoveSpeed=5f;
    public float smoothRotationTime = 0.25f;
    float currentVelocity;

    float currentSpeed;
    float speedVelocity;
    public float smoothSpeedTime = 0.1f;

    Transform cameraTransform;
    public bool enableMobileControls = true;
    public FixedJoystick joystick;

    public GameObject BulletPrefab;
    public Transform SpawnPoint;
    public GameObject target;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();               
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerinput=Vector2.zero;
        if (enableMobileControls)
        {
            playerinput = new Vector2(joystick.input.x, joystick.input.y);
        }
        else
        {
            playerinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        
        Vector2 inputDir = playerinput.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smoothRotationTime);
        }
        float targetSpeed = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, smoothSpeedTime);
        

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        
        if (targetSpeed >= 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}

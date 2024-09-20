using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float Xaxis;
    public float Yaxis;
    public float RotationSensitivity = 8f;
    public float TouchRotationSensitivity = 0.2f;

    float rotationMax = -40f;
    float rotationMin = 80f;
    float smoothTime = 0.12f;

    public Transform player;
    Vector3 targetRotation;
    Vector3 currentVel;
    public bool enableMobileControls = false;
    public FixedTouchField touchField;

    public float camDis = 4f;

    private void Start()
    {
        if (enableMobileControls)
        {
            RotationSensitivity = 0.2f;
        }
    }

    void LateUpdate()
    {
        if (enableMobileControls)
        {
            Yaxis += touchField.TouchDist.x * RotationSensitivity;
            Xaxis -= touchField.TouchDist.y * RotationSensitivity;
        }
        else
        {
            Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
            Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
        }

        

        Xaxis = Mathf.Clamp(Xaxis, rotationMax, rotationMin);
        targetRotation =Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis),ref currentVel,smoothTime);
        transform.eulerAngles = targetRotation;

        gameObject.transform.position = player.position - transform.forward * camDis;
        
    }
}

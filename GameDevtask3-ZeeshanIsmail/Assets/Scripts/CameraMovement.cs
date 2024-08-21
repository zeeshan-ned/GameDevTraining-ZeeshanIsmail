using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset ;
    // Update is called once per frame
    void Update()
    {
        Vector3 TargetPos = Target.position + offset;
        TargetPos.x = 0;
        transform.position = TargetPos;
    }
}

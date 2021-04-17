using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusRotationLoop : MonoBehaviour
{
    public float rotationAngle = 30f;
    public float speed = 1f;
    public enum Axis { up, right, forward }
    public Axis rotationAxis = Axis.up;
    public Vector3 RotationAxis
    {
        get
        {
            return rotationAxis switch
            {
                Axis.right => Vector3.right,
                Axis.forward => Vector3.forward,
                _ => Vector3.up
            };
        }
    }

    private void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * rotationAngle;
        transform.localRotation = Quaternion.AngleAxis(angle, RotationAxis);
    }
}

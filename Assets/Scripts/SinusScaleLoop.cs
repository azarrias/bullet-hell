using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusScaleLoop : MonoBehaviour
{
    public float minScale = 1f;
    public float maxScale = 1.2f;
    public float speed = 2f;

    void Update()
    {
        float scale = minScale + Mathf.Abs(Mathf.Sin(Time.time * speed)) * (maxScale - minScale);
        transform.localScale = Vector3.one * scale;
    }
}

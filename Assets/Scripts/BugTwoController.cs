using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugTwoController : EnemyController
{
    public float frequency = 20.0f;
    public float magnitude = 0.5f;
    public Vector3 targetPosition;
    public float movingSpeed = 5f;
    private Vector3 axis;

    private void Start()
    {
        axis = transform.up;
    }

    protected override void RegularMove()
    {
        transform.position = Vector3.MoveTowards(transform.position + axis * Mathf.Sin(Time.time * frequency) * magnitude, targetPosition, movingSpeed * Time.deltaTime);
    }
}

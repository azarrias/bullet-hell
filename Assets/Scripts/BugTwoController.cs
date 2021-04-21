using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugTwoController : MonoBehaviour
{
    public float frequency = 20.0f;
    public float magnitude = 0.5f;
    public Vector3 targetPosition;
    public float movingSpeed = 5f;
    private Vector3 axis;
    private bool dead;
    public Vector2 dieVelocity;
    public float gravityMultiplier = 5;

    private void Start()
    {
        axis = transform.up;
    }

    void Update()
    {
        if (!dead)
        {
            transform.position = Vector3.MoveTowards(transform.position + axis * Mathf.Sin(Time.time * frequency) * magnitude, targetPosition, movingSpeed * Time.deltaTime);
        }
        else
        {
            dieVelocity += 0.5f * Physics2D.gravity * gravityMultiplier * Time.deltaTime;
            Vector2 newPosition = transform.position;
            newPosition += dieVelocity * Time.deltaTime;
            transform.position = newPosition;
        }
    }

    public void Kill()
    {
        dead = true;
    }
}

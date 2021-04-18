using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics2D : MonoBehaviour
{
    public float gravityMultiplier = 1f;
    private Vector2 velocity;
    private Rigidbody2D rigidbody;

    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        velocity += gravityMultiplier * Physics2D.gravity * Time.deltaTime;
        Vector2 deltaPosition = velocity * Time.deltaTime;
        Vector2 movement = Vector2.up * deltaPosition.y;
        Move(movement);
    }

    private void Move(Vector2 movement)
    {
        rigidbody.position += movement;
    }
}

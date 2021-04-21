using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask layerMask;
    private Vector2 velocity;

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition += velocity * speed * Time.deltaTime;
        transform.position = newPosition;

        var collider = Physics2D.OverlapCircle(transform.position, 0.5f, layerMask);
        if (collider != null)
        {
            Debug.Log("Hola");
        }
    }

    public void Init(Vector2 velocity)
    {
        this.velocity = velocity;
    }
}

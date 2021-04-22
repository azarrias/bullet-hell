using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask layerMask;
    private Vector2 velocity;
    private float gravityMultiplier;

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        velocity += Physics2D.gravity * gravityMultiplier * Time.deltaTime;
        Vector2 newPosition = transform.position;
        newPosition += velocity * speed * Time.deltaTime;
        transform.position = newPosition;

        var collider = Physics2D.OverlapCircle(transform.position, 0.5f, layerMask);
        if (collider != null)
        {
            if (layerMask == (layerMask | (1 << LayerMask.NameToLayer("Enemy"))))
            {
                collider.gameObject.GetComponent<EnemyController>().Kill();
            }
            else
            {
                collider.gameObject.GetComponent<CharacterController2D>().Damage();
            }

        }
    }

    public void Init(Vector2 velocity, float gravityMultiplier = 0f)
    {
        this.velocity = velocity;
        this.gravityMultiplier = gravityMultiplier;
    }
}

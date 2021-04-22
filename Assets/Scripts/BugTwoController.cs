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
        SetTimeToShoot(1f, 2f);
        axis = transform.up;
    }

    protected override void RegularMove()
    {
        transform.position = Vector3.MoveTowards(transform.position + axis * Mathf.Sin(Time.time * frequency) * magnitude, targetPosition, movingSpeed * Time.deltaTime);
        if (timeToShoot < 0f)
        {
            Fire();
            SetTimeToShoot(1f, 2f);
        }
    }

    private void Fire()
    {
        var relativePos = new Vector3(-1.2f, -1f, 0);
        var velocity = new Vector2(-10, 0);

        if (flipX)
        {
            relativePos.x *= -1;
            velocity.x *= -1;
        }

        GameObject projectile = Instantiate(projectilePrefab, transform.position + relativePos, Quaternion.identity);
        projectile.GetComponent<Projectile>().Init(velocity, 5);
    }
}

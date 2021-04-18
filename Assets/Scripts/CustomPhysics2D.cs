using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics2D : MonoBehaviour
{
    public float gravityMultiplier = 1f;
    public float minimumGroundNormalY = 0.65f;
    private bool grounded = false;

    private Vector2 velocity;
    private Rigidbody2D rb;
    private const float MINIMUM_MOVING_DISTANCE = 0.001f;
    private const float PADDING_RADIUS = 0.01f;

    private ContactFilter2D contactFilter;
    private RaycastHit2D[] raycastHitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> raycastHitBufferList = new List<RaycastHit2D>(16);

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Use the Physics2D settings to determine what layers are going to be checked for collisions
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        velocity += gravityMultiplier * Physics2D.gravity * Time.deltaTime;
        var deltaPosition = velocity * Time.deltaTime;
        var movement = Vector2.up * deltaPosition.y;
        Move(movement, true);
    }

    private void Move(Vector2 movement, bool yMovement)
    {
        // Check for collisions, only if we are moving
        var distance = movement.magnitude;
        if (distance > MINIMUM_MOVING_DISTANCE)
        {
            var count = rb.Cast(movement, contactFilter, raycastHitBuffer, distance + PADDING_RADIUS);
            raycastHitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                raycastHitBufferList.Add(raycastHitBuffer[i]);
            }

            for (int i = 0, c = raycastHitBufferList.Count; i < c; i++)
            {
                // Check the y component of raycast hits to determine if the object is grounded
                var currentNormal = raycastHitBufferList[i].normal;
                if (currentNormal.y > minimumGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        currentNormal.x = 0;
                    }
                }

                // Cancel out the part of the velocity that would be stopped by the collision
                var projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity -= projection * currentNormal;
                }

                // Avoid getting stuck in other colliders
                var modifiedDistance = raycastHitBufferList[i].distance - PADDING_RADIUS;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        rb.position += movement.normalized * distance;
    }
}

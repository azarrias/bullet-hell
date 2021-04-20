using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : CustomPhysicsObject2D
{
    public float jumpingSpeed = 7f;
    public float movingSpeed = 7f;

    private SpriteRenderer[] spriteRenderers;
    private bool flipX = false;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        flipX = spriteRenderers[0].flipX;
    }

    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

        targetVelocity.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpingSpeed;
        }
        // If the jump button is let vertical velocity is reduced
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y *= 0.5f;
            }
        }

        SetSpriteFlipX(targetVelocity.x);

        targetVelocity = targetVelocity * movingSpeed;
    }

    private void SetSpriteFlipX(float velocityX)
    {
        Debug.Log(velocityX);
        var spriteFlipX = flipX ? (velocityX > 0.01f) : (velocityX < -0.01f);
        if (spriteFlipX)
        {
            flipX = !flipX;
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : CustomPhysicsObject2D
{
    public float jumpingSpeed = 7f;
    public float movingSpeed = 7f;

    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

        targetVelocity.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpingSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y *= 0.5f;
            }
        }

        targetVelocity = targetVelocity * movingSpeed;
    }
}

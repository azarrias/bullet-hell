using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : CustomPhysicsObject2D
{
    public float jumpingSpeed = 7f;
    public float movingSpeed = 7f;
    public GameObject projectilePrefab;
    public float gunCooldownSeconds = 1.2f;

    private SpriteRenderer[] spriteRenderers;
    private Animator animator;
    private bool flipX = false;
    private float timerGunCooldown = -0.1f;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        flipX = spriteRenderers[0].flipX;
    }

    protected override void Update()
    {
        base.Update();
        timerGunCooldown -= Time.deltaTime;
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

    protected override void HandleInput()
    {
        base.HandleInput();

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / movingSpeed);

        var horizontal = Math.Abs(Input.GetAxis("Horizontal")) > 0.01;
        var vertical = Math.Abs(Input.GetAxis("Vertical")) > 0.01;
        animator.SetBool("horizontal", horizontal);
        animator.SetBool("vertical", vertical);
        if (Input.GetButtonDown("Fire1") && timerGunCooldown < 0f)
        {
            timerGunCooldown = gunCooldownSeconds;
            animator.SetTrigger("fire");
            Fire(horizontal, vertical);
        }
    }

    private void SetSpriteFlipX(float velocityX)
    {
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

    private void Fire(bool horizontal, bool vertical)
    {
        var relativePos = new Vector3(0, 0, 0);
        var velocity = new Vector2(0, 0);

        if (horizontal && vertical)
        {
            relativePos.x = 2.09f;
            relativePos.y = 0.69f;
            velocity.x = 1;
            velocity.y = 1;
        }
        else if (vertical)
        {
            relativePos.x = 0f;
            relativePos.y = 1.86f;
            velocity.y = 1;
        }
        else
        {
            relativePos.x = 2.22f;
            relativePos.y = -0.77f;
            velocity.x = 1;
        }

        if (flipX)
        {
            relativePos.x *= -1;
            velocity.x *= -1;
        }

        GameObject projectile = Instantiate(projectilePrefab, transform.position + relativePos, Quaternion.identity);
        projectile.GetComponent<Projectile>().Init(velocity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 20f;
    public float gravity = -20f;
    public Transform groundCheck;
    public float groundDistance = 0.05f;
    public float jumpHeight = 3f;
    public LayerMask groundMask;

    private Vector2 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxis("Horizontal") * speed;
        characterController.Move(Vector2.right * velocity.x * Time.deltaTime);

        var collider = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
        isGrounded = collider != null;
        if (isGrounded && velocity.y < 0)
        {
            // If the ground check went in too deep on the collider, restore the player position
            var contactY = collider.bounds.center.y + collider.bounds.extents.y;
            var overlapY = contactY - groundCheck.position.y;
            if (overlapY > 0.05)
            {
                var position = gameObject.transform.position;
                position.y += overlapY;
                gameObject.transform.position = position;
            }

            velocity.y = -2f;
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(Vector2.up * velocity.y * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 30f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector2 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxis("Horizontal") * speed;
        characterController.Move(Vector2.right * velocity.x * Time.deltaTime);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(Vector2.up * velocity.y * Time.deltaTime);
        }
    }
}

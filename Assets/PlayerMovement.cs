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
        Debug.Log(velocity.x);
        characterController.Move(Vector2.right * velocity.x * Time.deltaTime);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
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

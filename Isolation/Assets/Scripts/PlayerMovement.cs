using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CC;

    public float speed = 12f;

    public float gravity = -9.81f;

    public Transform groundcheck;

    public float grounddistance = 0.4f;

    public float jumpHeight = 3.0f;
    
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        CC.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
       
        velocity.y += gravity * Time.deltaTime;

        CC.Move(velocity * Time.deltaTime);
    }
}

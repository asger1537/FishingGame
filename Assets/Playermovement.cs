using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public CharacterController controller;

    float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 20f;

    public Transform checkGround;
    public float checkDistance = 1f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool groundCollision;

    // Update is called once per frame
    void Update()
    {
        groundCollision = Physics.CheckSphere(checkGround.position, checkDistance, groundMask);

        if(groundCollision && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
         
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

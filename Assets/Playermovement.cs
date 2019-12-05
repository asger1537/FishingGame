using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public CharacterController controller;

    float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.Space))
        {
            move += transform.up * -1f;
        }
        

        controller.Move(move * speed * Time.deltaTime);
    }
}

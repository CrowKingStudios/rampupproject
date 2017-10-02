﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP2 : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpHeight = 250f;

    private Rigidbody rb;
    private bool isGrounded;

    protected string horizontalAxis = "Horizontal2";
    protected string verticalAxis = "Vertical2";

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis(horizontalAxis), 0.0f, Input.GetAxis(verticalAxis));

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight);
            isGrounded = false;
        }
    }
}
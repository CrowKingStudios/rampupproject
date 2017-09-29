using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP2 : MonoBehaviour
{

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float jumpHeight = 250;

    private Rigidbody rb;
    private bool isGrounded;

    // Prevents player from jumping while still in the air
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            isGrounded = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal2"), 0.0f, Input.GetAxis("Vertical2"));

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpHeight);
            isGrounded = false;
        }
    }
}
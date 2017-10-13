using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpHeight = 250f;
    [SerializeField]
    protected string horizontalAxis;
    [SerializeField]
    protected string verticalAxis;
    [SerializeField]
    private KeyCode jump;

    private Rigidbody rb;
    private bool isGrounded;

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

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight);
            isGrounded = false;
        }
    }
}
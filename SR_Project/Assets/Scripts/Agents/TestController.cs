using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;

    private Rigidbody rb;
    private float xDirection, zDirection;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        xDirection = Input.GetAxis("Vertical");
        zDirection = -Input.GetAxis("Horizontal");
        
        bool IsGrounded() {
            return Physics.Raycast(transform.position, -Vector3.up, 0.51f);
        }

        if (Input.GetKeyDown(KeyCode.Space) & IsGrounded()) {
            rb.velocity += Vector3.up * jumpPower;
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(xDirection * speed, rb.velocity.y, zDirection * speed);
    }
}

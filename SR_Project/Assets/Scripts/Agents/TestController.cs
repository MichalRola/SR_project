using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpPower = 8.0f;
    Rigidbody rb;

    float xDirection, zDirection;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        xDirection = Input.GetAxis("Vertical");
        zDirection = -Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector3.up * jumpPower;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(xDirection * speed, rb.velocity.y, zDirection * speed);
    }
}

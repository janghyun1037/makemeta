using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    int jumpCount = 0;
    public float jumpPower;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Move();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (jumpCount > 1) jumpCount = 1;
            jumpCount = 1;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 1 && jumpCount > 0)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += h * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
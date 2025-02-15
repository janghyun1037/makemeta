using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public int HP;
    public int jumpCount = 0;
    public float jumpPower;
    public float moveSpeed;

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
        if (collision.gameObject.tag == "Door")
        {
            SceneManager.LoadScene("Home");
        }
        if (collision.gameObject.tag == "DDR")
        {
            SceneManager.LoadScene("InGame");
        }
        if (collision.gameObject.tag == "Jump")
        {
            jumpPower = 8;
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

    void Ability()
    {
        
    }

    void NormalAttack()
    {

    }
}
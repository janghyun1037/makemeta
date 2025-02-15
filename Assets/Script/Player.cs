using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
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

    void sensing()//키감지 나중에 없애도 됨
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q스킬");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E스킬");
        }
    }
}
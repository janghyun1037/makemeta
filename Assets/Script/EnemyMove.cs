using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    Transform player;
    private int rotateSpeed = 2;
    private float moveSpeed = 5f;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector2 direction = new Vector2(transform.position.x - player.position.x, player.position.y);

        Vector3 dir = direction;
        transform.position += (-dir.normalized * moveSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Find();
        }
    }
    void Find()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    Transform Player;
    //private int rotateSpeed = 2;
    private float Speed = 5f;
    //public SpriteRenderer spriteRenderer;
    private float stopDistance = 8f;
    private Transform target;
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    //Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
        //Rotate();
        //Find();
    }

    //void Rotate()
    //{
    //    Vector2 direction = new Vector2(transform.position.x - Player.position.x, Player.position.y);

    //    Vector3 dir = direction;
    //    transform.position += (-dir.normalized * moveSpeed * Time.deltaTime);
    //}
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Find();
    //    }
    //}
    void Find()
    {
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        if (Vector2.Distance(transform.position, Player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
    }
}
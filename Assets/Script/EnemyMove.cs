using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform target;

    public float Speed;
    private float stopDistance = 5f;
    public int HP;
    public int damage;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        EnemyData.EnemyStat? enemyStat = EnemyData.instance.enemyList.Find(e => e.enemyName == gameObject.name);

        if (enemyStat.HasValue)
        {
            HP = enemyStat.Value.health;
            Speed = enemyStat.Value.speed;
            damage = enemyStat.Value.damage;
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Vector2.Distance(transform.position, target.position) < stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
    }

    public void Damaged(int damage)
    {
        HP -= damage;
        
        if (HP <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        EnemyData.instance.SetDeathEnemy(gameObject.name);
        Destroy(gameObject);
    }
}
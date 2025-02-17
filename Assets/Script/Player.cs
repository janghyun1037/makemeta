using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public int HP = 10;
    public int jumpCount = 0;
    public int jumpNum = 1;
    public float jumpPower = 3;
    public float moveSpeed = 1;
    public int damage = 1;

    public float curTime;
    public float coolTime = 0.5f;

    public Transform pos;
    public Vector2 boxSize;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Move();
        Ability();
        NormalAttack();
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
            jumpCount = jumpNum;
        }
        if(collision.gameObject.tag == "enemy")
        {
            HP--;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= jumpNum && jumpCount > 0)
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
        if(string.IsNullOrEmpty(EnemyData.instance.deathEnemy))
        {
            return;
        }

        string lastEnemy = EnemyData.instance.deathEnemy;

        EnemyData.EnemyStat? enemyStat = EnemyData.instance.enemyList.Find(e => e.enemyName == lastEnemy);

        if (enemyStat.HasValue)
        {
            HP = enemyStat.Value.health;
            moveSpeed = enemyStat.Value.speed;
            damage = enemyStat.Value.damage;
        }

    }

    public void NormalAttack()
    {
        if (curTime <= 0)
        {
            if (Input.GetKey(KeyCode.C))
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);

                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<EnemyMove>().Damaged(damage);
                    }
                }
                curTime = coolTime;

            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
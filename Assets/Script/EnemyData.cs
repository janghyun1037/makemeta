using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public static EnemyData instance;
    public string deathEnemy;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public struct EnemyStat
    {
        public string enemyName;
        public int health;
        public int damage;
        public float speed;

        public EnemyStat(string enemyName, int health, int damage, float speed)
        {
            this.enemyName = enemyName;
            this.health = health;
            this.damage = damage;
            this.speed = speed;
        }
    }

    public List<EnemyStat> enemyList = new List<EnemyStat>()
    {
        new EnemyStat("����", 3, 10, 7),
        new EnemyStat("�ü�", 5, 7, 7),
        new EnemyStat("���", 6, 15, 4),
        new EnemyStat("������", 10, 7, 3),
        new EnemyStat("����", 15, 30, 6),
        new EnemyStat("����", 30, 20, 10),
        new EnemyStat("��Ȳ", 100, 100, 20)
    };

    public void SetDeathEnemy(string enemyName)
    {
        deathEnemy = enemyName;
    }
}

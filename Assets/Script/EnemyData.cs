using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyStat
{
    public string enemyName;
    public int health;
    public int damage;
    public int speed;
    public EnemyStat(string enemyName, int health, int damage, int speed)
    {
        this.enemyName = enemyName;
        this.health = health;
        this.damage = damage;
        this.speed = speed;
    }
}

public class EnemyData : MonoBehaviour
{
    public List<EnemyStat> enemyList = new List<EnemyStat>();

    void Start()
    {
        enemyList.Add(new EnemyStat("����", 3, 10, 7));
        enemyList.Add(new EnemyStat("�ü�", 5, 7, 7));
        enemyList.Add(new EnemyStat("���", 6, 15, 4));
        enemyList.Add(new EnemyStat("������", 10, 7, 3));
        enemyList.Add(new EnemyStat("����", 15, 30, 6));
        enemyList.Add(new EnemyStat("����", 30, 20, 10));
        enemyList.Add(new EnemyStat("��Ȳ", 100, 100, 20));
    }
}
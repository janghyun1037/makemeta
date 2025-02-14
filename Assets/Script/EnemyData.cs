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
        enemyList.Add(new EnemyStat("닌자", 3, 10, 7));
        enemyList.Add(new EnemyStat("궁수", 5, 7, 7));
        enemyList.Add(new EnemyStat("기사", 6, 15, 4));
        enemyList.Add(new EnemyStat("마법사", 10, 7, 3));
        enemyList.Add(new EnemyStat("주하", 15, 30, 6));
        enemyList.Add(new EnemyStat("현우", 30, 20, 10));
        enemyList.Add(new EnemyStat("주황", 100, 100, 20));
    }
}
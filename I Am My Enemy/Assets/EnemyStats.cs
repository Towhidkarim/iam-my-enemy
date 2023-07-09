using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats 
{

    public float health;
    public float speed;
    public float maxHealth;
    public float maxSpeed;
    public float damage;
    public string enemeyName;
    public string weaponName;

    public EnemyStats(float maxHealth, float maxSpeed, float damage)
    {
        this.health = maxHealth;
        this.speed = maxSpeed;
        this.maxHealth = maxHealth;
        this.maxSpeed = maxSpeed;
        this.damage = damage;
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
        if(this.health < 0) this.health = 0;
    }
    
    
}

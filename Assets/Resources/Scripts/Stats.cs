using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public SideTag sideTag;
    public float speed;
    public int maxHealth;
    public int health;
    public int damage;
    public float shootDelay;
    public float shootDelayMultiplier;
    public float bulletSpeed = 15f;

    public Stats(SideTag sideTag, float speed,int health, int damage, float shootDelay, float shootDelayMultiplier, float bulletSpeed)
    {
        this.sideTag = sideTag;
        this.speed = speed;
        this.maxHealth = health;
        this.health = maxHealth;
        this.damage = damage;
        this.shootDelay = shootDelay;
        this.shootDelayMultiplier = shootDelayMultiplier;
        this.bulletSpeed = bulletSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class MusuhStats : Stats
{
    public int scoreDrop;
    public int spDrop;

    public MusuhStats(SideTag sideTag, float speed, int health, int damage, float shootDelay, float shootDelayMultiplier, float bulletSpeed,int scoreDrop,int SPDrop) : base (sideTag,speed,health,damage,shootDelay,shootDelayMultiplier,bulletSpeed)
    {
        this.sideTag = sideTag;
        this.speed = speed;
        this.maxHealth = health;
        this.health = maxHealth;
        this.damage = damage;
        this.shootDelay = shootDelay;
        this.shootDelayMultiplier = shootDelayMultiplier;
        this.bulletSpeed = bulletSpeed;
        this.scoreDrop = scoreDrop;
        this.spDrop = SPDrop;
    }
}

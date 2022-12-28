using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musuh5 : Musuh
{
    public bool isDamagedShoot;

    public override void Damaged(int damage)
    {
        base.Damaged(damage);
        if (isDamagedShoot)
        {
            if (stats.health > 0)
                Tembakin();
        }
    }
    public override void Mati()
    {
        base.Mati();
        Tembakin();
    }
    protected override void Tembak()
    {
      
    }
    public void Tembakin()
    {
        for (int i = 0; i <= 360; i += 45)
        {
            TembakBullet(i);
        }
        Soundmanager.Instance.PlaySfx("Shoot");
    }


    protected void TembakBullet(float angle)
    {
        GameObject g = ObjectPool.Instance.GetBullet();
        Bullet b = g.GetComponent<Bullet>();
        g.gameObject.SetActive(true);
        //  b.GetComponent<SpriteRenderer>().color = Color.blac
        if (stats.sideTag == SideTag.player)
        {
            b.Warnain(Color.red);
        }
        else if (stats.sideTag == SideTag.musuh)
        {
            b.Warnain(Color.yellow);
        }
        g.transform.position = transform.position;
        g.transform.rotation = Quaternion.Euler(0,0,angle);
        b.damage = stats.damage;
        b.speed = stats.bulletSpeed;
        b.tagSide = stats.sideTag;
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    protected List<Gun> tembakan = new List<Gun>();
    public Transform tempatTembak;
    public Stats stats;
    Animator anim;
    SpriteRenderer muzzle;
    private void Start()
    {
        anim = GetComponent<Animator>();
        muzzle = transform.Find("TempatTembak/Muzzle").GetComponent<SpriteRenderer>();
    }


    public void Tembak()
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
        g.transform.position = tempatTembak.position;
        g.transform.rotation = tempatTembak.rotation;
        b.damage = stats.damage;
        b.speed = stats.bulletSpeed;
        b.tagSide = stats.sideTag;
        anim.SetTrigger("Muzzle");
    }
    public void DisableMuzzle()
    {
        muzzle.color = new Color(muzzle.color.r, muzzle.color.g, muzzle.color.b, 0); 
    }

}

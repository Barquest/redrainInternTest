using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SideTag {player,musuh}
public class Bullet : MonoBehaviour
{
    public SideTag tagSide = SideTag.player;
    public float speed = 5f;
    public int damage = 1;
    SpriteRenderer sRend;
    private void Start()
    {
      //  sRend = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        transform.Translate(transform.right * Time.deltaTime * speed, Space.World);
    }
    public void Warnain(Color color)
    {
        sRend.color = color;
    }
    public void Setup()
    { 
    }
    public void Impact()
    {
        GameObject imp = ObjectPool.Instance.GetBulletImpact();
        ParticleSystem p = imp.GetComponent<ParticleSystem>();
        p.startColor = sRend.color;
        imp.SetActive(true);
        imp.transform.position = this.transform.position;
        p.Play();
        
    }
    private void OnEnable()
    {
        if (sRend == null)
            sRend = GetComponent<SpriteRenderer>();
        StartCoroutine(Disable());
    }
    public IEnumerator Disable()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}

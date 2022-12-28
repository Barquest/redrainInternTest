using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musuh : MonoBehaviour
{
    public MusuhStats stats;

    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    bool isDamaged;

    protected List<Gun> tembakan = new List<Gun>();
    float tembakCd;
    public Color destroyedColor;

    protected virtual void Start()
    {
        myRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
        SetupGun();
    }
    public virtual void Setup()
    {
        stats.health = stats.maxHealth;
    }
    protected virtual void Tembak()
    {
        for (int i = 0; i < tembakan.Count; i++)
        {
            tembakan[i].Tembak();
        }
        //Soundmanager.Instance.PlaySfx("Shoot2");
    }
    protected virtual void SetupGun()
    {
        foreach (Transform t in transform.Find("Sprite"))
        {
            Gun g = t.GetComponent<Gun>();
            g.stats = stats;
            tembakan.Add(g);
        }
        /*

        Gun g = transform.Find("Sprite/Gun").GetComponent<Gun>();
        g.stats = stats;
        tembakan.Add(g);*/
    }
    protected virtual void FixedUpdate()
    {
        Move();
    }
    public virtual void Move()
    {
        transform.Translate(-Vector2.right * Time.deltaTime * stats.speed);
    }
    protected virtual void Update()
    {
        if (tembakCd > 0)
        {
            tembakCd -= Time.deltaTime;
        }
        else if (tembakCd < 0)
        {
            tembakCd = 0;
        }
        if (tembakCd == 0)
        {
            tembakCd = (stats.shootDelay * stats.shootDelayMultiplier);
            Tembak();
        }
        if (transform.position.x < -15)
        {
            Hilang();
        }
    }
    void WhiteSprite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
        isDamaged = true;
    }
    void NormalSprite()
    {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
        isDamaged = false;
    }
    public IEnumerator WhiteDamagedAnimation()
    {
      
        WhiteSprite();
        yield return new WaitForSeconds(0.1f);
        NormalSprite();
     
    }
    public virtual void Damaged(int damage)
    {
        if (!gameObject.activeInHierarchy)
            return;
        if (!isDamaged)
            StartCoroutine(WhiteDamagedAnimation());
        stats.health -= damage;
        Soundmanager.Instance.PlaySfx("Hit");
        if (stats.health <= 0)
            Mati();
    }
    public virtual void Mati()
    {
        NormalSprite();
        GameObject g = ObjectPool.Instance.GetDestroyedParticle();
        g.transform.position = this.transform.position;
        g.SetActive(true);
        g.GetComponent<ParticleSystem>().startColor = destroyedColor;
        GameManager.Instance.TambahScore(stats.scoreDrop);
        MusuhSpawner.Instance.DeleteMusuhDariScene(this.gameObject);
        gameObject.SetActive(false);
        StopAllCoroutines();
        DropSP();
        tembakCd = stats.shootDelay;
        CheckSpawnPowerUp();
        Soundmanager.Instance.PlaySfx("Explode");
        for (int i = 0; i < tembakan.Count; i++)
        {
            tembakan[i].DisableMuzzle();
        }

    }
    public virtual void CheckSpawnPowerUp()
    {
        float r = Random.Range(0, GameManager.Instance.pickupDropChance);
        if (r <= 1f)
        {
            PowerUpManager pum = GameManager.Instance.player.powerUp;
            Instantiate(pum.powerUpPickupPrefab[Random.Range(0, pum.powerUpPickupPrefab.Length)], transform.position, Quaternion.identity);

        }
    }
    public virtual void Hilang()
    {
        NormalSprite();
        MusuhSpawner.Instance.DeleteMusuhDariScene(this.gameObject);
        gameObject.SetActive(false);
    }
    public void DropSP()
    {
        GameObject sp = ObjectPool.Instance.GetSp();
        sp.GetComponent<SpPickup>().drop = stats.spDrop;
        sp.transform.position = this.transform.position;
        sp.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Bullet b = collision.GetComponent<Bullet>();
            if (b.tagSide == SideTag.player)
            {
                b.Impact();
                Damaged(b.damage);
                b.gameObject.SetActive(false);
              
            }
        }
    }
}

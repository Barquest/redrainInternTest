using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxKiri = -11f;
    public float maxKanan = 9.5f;
    public float maxAtas = 9.5f;
    public float maxBawah = 1f;

    public Stats playerStats;

    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    private GameManager gm;
    public PowerUpManager powerUp;
    bool isDamaged;
    // Update is called once per frame
    private void Start()
    {
        gm = GameManager.Instance;
        myRenderer = transform.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
        powerUp = GetComponent<PowerUpManager>();
        playerStats.health = playerStats.maxHealth;
    }
    void FixedUpdate()
    {
        transform.Translate(transform.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime *playerStats.speed, Space.World);
        transform.Translate(transform.up * Input.GetAxisRaw("Vertical") * Time.deltaTime * playerStats.speed, Space.World);
        transform.position = new Vector2(Mathf.Max(maxKiri, transform.position.x), Mathf.Min(maxAtas, transform.position.y));
        transform.position = new Vector2(Mathf.Min(maxKanan, transform.position.x), Mathf.Max(maxBawah, transform.position.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Bullet b = collision.GetComponent<Bullet>();
          
            if (b.tagSide == SideTag.musuh)
            {
                if (powerUp.isShield)
                {
                    powerUp.TookShieldDamage();
                }
                else {
                    Damaged(b.damage);
                }
                b.gameObject.SetActive(false);
                b.Impact();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Musuh"))
        {
            collision.gameObject.GetComponent<Musuh>().Mati();
            if (powerUp.isShield)
            {
                powerUp.TookShieldDamage();
            }
            else
            {
                Damaged(1);
            }
        }
    }
    void WhiteSprite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
    }
    void NormalSprite()
    {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }
    public IEnumerator WhiteDamagedAnimation()
    {
        isDamaged = true;
        WhiteSprite();
        yield return new WaitForSeconds(0.1f);
        NormalSprite();
        isDamaged = false;
    }
    public virtual void Damaged(int damage)
    {
        if (!isDamaged)
            StartCoroutine(WhiteDamagedAnimation());
        playerStats.health -= damage;
        Soundmanager.Instance.PlaySfx("Hit");
        UIManager.Instance.DisplayPlayerHealth();
        if (playerStats.health <= 0)
            Mati();
    }
    public virtual void Mati()
    {
        gameObject.SetActive(false);
        GameManager.Instance.GameKalah();
        Soundmanager.Instance.PlaySfx("Explode");
    }
}

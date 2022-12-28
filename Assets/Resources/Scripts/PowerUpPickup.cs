using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    public string namaPowerUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (namaPowerUp == "Shield")
            {
                collision.gameObject.GetComponent<PowerUpManager>().ShieldOn();
                gameObject.SetActive(false);
            }
            else if (namaPowerUp == "AttackSpeed")
            {
                collision.gameObject.GetComponent<PowerUpManager>().AttackSpeedPowerup();
                gameObject.SetActive(false);
            }
            else if (namaPowerUp == "Heal")
            {
                collision.gameObject.GetComponent<PowerUpManager>().Heal();
                gameObject.SetActive(false);
            }
            Soundmanager.Instance.PlaySfx("Pickup2");
        }
    }
    private void Start()
    {
        Invoke("Hilang", 40f);
    }
    public void Hilang()
    {
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        transform.Translate(-Vector2.right * 0.5f * Time.deltaTime);
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}

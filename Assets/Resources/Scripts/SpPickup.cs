using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpPickup : MonoBehaviour
{
    public int drop = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameManager.Instance.TambahSP(drop);
            gameObject.SetActive(false);
            CancelInvoke("Hilang");
            Soundmanager.Instance.PlaySfx("Pickup1");
        }
    }
    private void Start()
    {
        Invoke("Hilang", 40f);
    }
    public void Hilang()
    {
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        transform.Translate(-Vector2.right * 1 * Time.deltaTime);
        if (transform.position.x < -15)
        {
            gameObject.SetActive(false);
        }
    }
}

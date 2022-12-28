using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UpgradeStatsButton : MonoBehaviour
{
    public UnityEvent e;
    public int hargaSP = 15;
    public TextMeshProUGUI hargaText;

    private void Start()
    {
        hargaText.text = "<sprite=0> : " + hargaSP;
    }

    public void Click()
    {
        Debug.Log("Click");
        if (GameManager.Instance.Sp >= hargaSP)
        {
            e.Invoke();
            GameManager.Instance.Sp -= hargaSP;
            Destroy(gameObject);
            UIManager.Instance.MasukinUpgradeStats();
            UIManager.Instance.DisplaySp();
            UIManager.Instance.SpUpgradeDisplay();
            Soundmanager.Instance.PlaySfx("UI_Click");
        }
    }
    public void ClickLevelUp()
    {
        Debug.Log("Click");
        if (GameManager.Instance.Sp >= hargaSP)
        {
            e.Invoke();
            GameManager.Instance.Sp -= hargaSP;
            gameObject.SetActive(false);          
            UIManager.Instance.DisplaySp();
            UIManager.Instance.SpUpgradeDisplay();
        }
    }
    public void PlusMaxHealth()
    {
        GameManager.Instance.player.playerStats.maxHealth += 1;
        GameManager.Instance.player.playerStats.health = GameManager.Instance.player.playerStats.maxHealth;
        UIManager.Instance.DisplayPlayerHealth();
    }
    public void PlusDamage()
    {
        GameManager.Instance.player.playerStats.damage += 1;
    }
    public void PlusAttackSpeed20()
    {
        GameManager.Instance.player.playerStats.shootDelay *= 0.9f;
    }
    public void PlusAttackSpeed40()
    {
        GameManager.Instance.player.playerStats.shootDelay *= 0.6f;
    }
    public void PlusMoveSpeed20()
    {
        GameManager.Instance.player.playerStats.speed *= 1.2f;
    }
    public void PlusMoveSpeed40()
    {
        GameManager.Instance.player.playerStats.speed *= 1.4f;
    }
    public void PlusPowerUpDuration()
    {
        GameManager.Instance.powerUpDuration += 1;
    }
    public void Levelup()
    {
        UpgradeStatsManager.Instance.LevelUpPlayer();
    }

}

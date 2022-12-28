using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [Header("Shield")]
    public bool isShield;
    public IEnumerator coroutineRunning;
    public GameObject shieldSprite;

    public GameObject[] powerUpPickupPrefab;
    // Start is called before the first frame update
    public void TookShieldDamage()
    {
       // StopCoroutine(Shielding());
       // ShieldOff();
    }
    public void ShieldOff()
    {
        isShield = false;
        shieldSprite.gameObject.SetActive(false);
 
    }
    public void Heal()
    {
        GameManager.Instance.player.playerStats.health+= (GameManager.Instance.powerUpDuration-1);
        if (GameManager.Instance.player.playerStats.health > GameManager.Instance.player.playerStats.maxHealth)
        {
            GameManager.Instance.player.playerStats.health = GameManager.Instance.player.playerStats.maxHealth;

        }
        UIManager.Instance.DisplayPlayerHealth();
    }
    public void ShieldOn()
    {
        coroutineRunning = Shielding();
        StopCoroutine(coroutineRunning);
        StartCoroutine(coroutineRunning);
    }
    public void AttackSpeedPowerup()
    {
        StartCoroutine(AttackSpeedUp());
    }
    public IEnumerator AttackSpeedUp()
    {
        GameManager.Instance.player.playerStats.shootDelayMultiplier /= 2;
        yield return new WaitForSeconds(GameManager.Instance.powerUpDuration + 3f);
        GameManager.Instance.player.playerStats.shootDelayMultiplier *= 2;
    }
    public IEnumerator Shielding()
    {
        isShield = true;
        shieldSprite.gameObject.SetActive(true);
        yield return new WaitForSeconds(GameManager.Instance.powerUpDuration);
        ShieldOff();
    }
}

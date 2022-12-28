using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    protected List<Gun> tembakan = new List<Gun>();
    PlayerController player;
    GameManager gm;
    bool isNembak;
    float tembakCd;

    public int level = 1;
    private void Start()
    {
        gm = GameManager.Instance;
        player = GetComponent<PlayerController>();
        UIManager.Instance.GetPlayerStats(player.playerStats);
        Setup();
        tembakCd = 0;
    }
    public void Setup()
    {
        Gun g = transform.Find("PlayerSprite/Gun").GetComponent<Gun>();
        g.stats = player.playerStats;
        tembakan.Add(g);
      
    }
    public void LevelUp()
    {
        if (level == 1)
        {
            Gun g2 = transform.Find("PlayerSprite/Gun 2").GetComponent<Gun>();
            g2.gameObject.SetActive(true);
            g2.stats = player.playerStats;
            tembakan.Add(g2);
            level++;
        }
        else if (level == 2)
        {
            Gun g3 = transform.Find("PlayerSprite/Gun 3").GetComponent<Gun>();
            g3.gameObject.SetActive(true);
            g3.stats = player.playerStats;
            tembakan.Add(g3);
            Gun g4 = transform.Find("PlayerSprite/Gun 4").GetComponent<Gun>();
            g4.gameObject.SetActive(true);
            g4.stats = player.playerStats;
            tembakan.Add(g4);
            level++;
        }
    }
    private void Update()
    {
        if (gm.isInUI)
            return;
        if (tembakCd > 0)
        {
            tembakCd -= Time.deltaTime;
        }
        else if (tembakCd < 0)
        {
            tembakCd = 0;
        } 
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            isNembak = true;
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            isNembak = false;
        }
        if (isNembak && tembakCd == 0) {
            tembakCd = (player.playerStats.shootDelay*player.playerStats.shootDelayMultiplier);
            for (int i = 0; i < tembakan.Count; i++)
            {
                tembakan[i].Tembak();
            }
            Soundmanager.Instance.PlaySfx("Shoot");
        }
    }
}

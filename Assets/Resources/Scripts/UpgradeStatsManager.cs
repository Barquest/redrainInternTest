using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStatsManager : MonoBehaviour
{
    public static UpgradeStatsManager Instance;
    UIManager ui;
    public int hargaUpgradeTier1 = 75;
    public int hargaUpgradeTier2 = 200;
    public int hargaReroll = 2;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ui = UIManager.Instance;
    }
    public void LevelUpPlayer()
    {
        GameManager.Instance.player.GetComponent<PlayerShoot>().LevelUp();
    }
}

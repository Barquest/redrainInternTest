using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Transform playerHealthDisplay;
    public GameObject heartPrefab;
    public Sprite emptyHeart;
    public Sprite filledHeart;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI spText;
    [Header("Game Over")]
    public GameObject GameOverPanel;
    public TextMeshProUGUI GameOverJudulText;
    public TextMeshProUGUI GameOverScoreText;
    public TextMeshProUGUI GameOverHighscoreText;
    public GameObject RetryGameButton;
    public GameObject ExitGameButton;

    [Header("Upgrade Stats")]
    public GameObject upgradePanel;
    public TextMeshProUGUI upgradeSpText;
    public GameObject[] UpgradeStatsPrefab;
    public Transform UpgradeStatsListParent;
    public GameObject levelupButton;
    public TextMeshProUGUI levelUpText;
    public TextMeshProUGUI levelUpHargaText;
    public TextMeshProUGUI rerollHargaText;

    [Header("Path Choose")]
    public GameObject pathChoosePanel;
    PathChooseManager pathChoose;

    protected Stats playerStats;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        pathChoose = PathChooseManager.Instance;
        GameOverPanel.SetActive(false);
        upgradePanel.SetActive(false);
        ClosePathChoosePanel();
        DisplayScore();
        DisplaySp();
    }
    public void OpenPathChoosePanel()
    {
        pathChoosePanel.SetActive(true);
    }
    public void ClosePathChoosePanel()
    {
        pathChoosePanel.SetActive(false);
    }
    public void EasyButtonPress()
    {
        pathChoose.ChooseEasy();
        ClickSound();

    }
    public void HardButtonPress()
    {
        pathChoose.ChooseHard();
        ClickSound();


    }
    public void OpenUpgradePanel() {
        upgradePanel.SetActive(true);
        UpgradePanelSpDisplay();
    }
    public void NextButton()
    {
        upgradePanel.SetActive(false);
        OpenPathChoosePanel();
        ClickSound();
    }
    public void ClickSound()
    {
        Soundmanager.Instance.PlaySfx("UI_Click");
    }
    public void RerollUpgradeStats()
    {
        if (GameManager.Instance.Sp >= UpgradeStatsManager.Instance.hargaReroll)
        {
            GameManager.Instance.Sp -= UpgradeStatsManager.Instance.hargaReroll;
            ClearUpdateList();
            for (int i = 0; i < 3; i++)
            {
                MasukinUpgradeStats();
            }
            SpUpgradeDisplay();
            ClickSound();

        }
    }
    public void UpgradePanelSpDisplay()
    {
        upgradeSpText.text = "<sprite=0> : " + GameManager.Instance.Sp;
        rerollHargaText.text = "Reroll <sprite=0> " + UpgradeStatsManager.Instance.hargaReroll;
        ClearUpdateList();
        for (int i = 0; i < 3; i++)
        {
            MasukinUpgradeStats();
        }
        PlayerShoot ps = GameManager.Instance.player.GetComponent<PlayerShoot>();
        if (ps.level < 3)
        {
            levelupButton.SetActive(true);
            if (ps.level == 1)
            {
                levelUpText.text = "Level UP \n+1 Gun";
                levelUpHargaText.text = "<sprite=0> " +UpgradeStatsManager.Instance.hargaUpgradeTier1;
                levelupButton.GetComponent<UpgradeStatsButton>().hargaSP = UpgradeStatsManager.Instance.hargaUpgradeTier1;
            }
            else if (ps.level == 2)
            {
                levelUpText.text = "Level UP \n+2 Gun";
                levelUpHargaText.text = "<sprite=0> " + UpgradeStatsManager.Instance.hargaUpgradeTier2;
                levelupButton.GetComponent<UpgradeStatsButton>().hargaSP = UpgradeStatsManager.Instance.hargaUpgradeTier2;
            }
        }
        else {
            levelupButton.SetActive(false);
        }
       
    }
    public void SpUpgradeDisplay() {
        upgradeSpText.text = "<sprite=0> : " + GameManager.Instance.Sp;

    }
    public void MasukinUpgradeStats()
    {
        
            GameObject g = Instantiate(UpgradeStatsPrefab[Random.Range(0, UpgradeStatsPrefab.Length)], UpgradeStatsListParent);
        

    }
    public void ClearUpdateList()
    {
        foreach (Transform t in UpgradeStatsListParent)
        {
            Destroy(t.gameObject);
        }
    }
    public void GetPlayerStats(Stats stats)
    {
        playerStats = stats;
        DisplayPlayerHealth();
    }
    public void DisplayScore()
    {
        scoreText.text = "Score : " + GameManager.Instance.score;
    }
    public void DisplaySp()
    {
        spText.text = "<sprite=0> : " + GameManager.Instance.Sp;
    }
    public void DisplayPlayerHealth()
    {
        foreach (Transform t in playerHealthDisplay)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < playerStats.maxHealth; i++)
        {
            GameObject h = Instantiate(heartPrefab, playerHealthDisplay);
            if (i <= (playerStats.health - 1))
            {

                h.GetComponent<Image>().sprite = emptyHeart;
            }
            else
            {
                h.GetComponent<Image>().sprite = filledHeart;
            }
        }
    }
    public void DisplayGameOverKalah()
    {
        GameOverPanel.SetActive(true);
        GameOverJudulText.text = "Kamu Kalah...\nCoba Lagi?";
        RetryGameButton.SetActive(true);
        ExitGameButton.SetActive(true);
        GameOverHighscoreText.text = "";
        GameOverScoreText.text = "Score : " + GameManager.Instance.score;
    }
    public void DisplayGameOverMenang()
    {
        GameOverPanel.SetActive(true);
        GameOverJudulText.text = "Selamat Kamu Menang!";
        RetryGameButton.SetActive(true);
        ExitGameButton.SetActive(true);
        GameOverHighscoreText.text = "High Score : " +PlayerPrefs.GetInt("Highscore",0).ToString();
        GameOverScoreText.text = "Score : " + GameManager.Instance.score;
    }
    public void RetryButton()
    {
        GameManager.Instance.RetryGame();
    }
    public void ExitButton()
    {
        GameManager.Instance.ExitGame();
    }
}

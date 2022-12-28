using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum path{easy,hard}

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public path pathChoosen = path.easy;
    public UIManager ui;
    public int score;
    public int Sp;
    public int powerUpDuration = 2;
    public bool isgameOver;
    public PlayerController player;
    public float pickupDropChance = 5;
    public bool isInUI;
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ui = UIManager.Instance;
        player = FindObjectOfType<PlayerController>();
        Soundmanager.Instance.PlayMusic("BGM");
    }
    public void TambahScore(int tambahan)
    {
        score += tambahan;
        UIManager.Instance.DisplayScore();
    }
    public void TambahSP(int tambahan)
    {
        Sp += tambahan;
        UIManager.Instance.DisplaySp();
    }
    public void GameMenang()
    {
        isgameOver = true;
        isInUI = true;
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        ui.DisplayGameOverMenang();
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GameKalah()
    {
        isInUI = true;
        isgameOver = true;
        ui.DisplayGameOverKalah();
    }

  

}

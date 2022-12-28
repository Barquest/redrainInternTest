using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChooseManager : MonoBehaviour
{
    public static PathChooseManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void ChooseEasy()
    {
        GameManager.Instance.pathChoosen = path.easy;
        UIManager.Instance.ClosePathChoosePanel();
       // MusuhSpawner.Instance.NextStage();
        MusuhSpawner.Instance.Invoke("NextStage", 3f);
        GameManager.Instance.isInUI = false;
    }
    public void ChooseHard()
    {
        GameManager.Instance.pathChoosen = path.hard;
        UIManager.Instance.ClosePathChoosePanel();
        //MusuhSpawner.Instance.NextStage();
        MusuhSpawner.Instance.Invoke("NextStage", 3f);
        GameManager.Instance.isInUI = false;
    }
}

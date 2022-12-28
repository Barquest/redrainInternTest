using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusuhData
{
    public string nama;
    [Range(-6,6)]
    public int startingY;
    public float delay;
    //public string custom;
    
}
public class MusuhSpawner : MonoBehaviour
{
    public float posx;
    public void SpawnMusuh(string musuhNama, float posy)
    {
        if (musuhNama == "Musuh1")
        {
            GameObject m = ObjectPool.Instance.GetMusuh1();
            m.SetActive(true);
            m.transform.position = new Vector2(posx, posy);
        }

    }
    public List<GameObject> musuhInScene;
    public List<EnemyWave> wave;
    public List<Stage> easyStages;
    public List<Stage> hardStages;
    public Stage currentStage;
    public EnemyWave currentWave;

    public static MusuhSpawner Instance;
    public int waveCount;
    public int currentStageCount;
    bool isSelesaiSpawn;

    private void Awake()
    {
        Instance = this;
    }
    public void Ratain()
    {
        foreach (GameObject m in musuhInScene)
        {
            //DeleteMusuhDariScene(m);
            m.SetActive(false);
        }
    }
    public void NextWave()
    {
        if (GameManager.Instance.isgameOver)
            return;
        waveCount++;
        if (waveCount < currentStage.waves.Count)
        {
            SpawnWave();
        }
        else
        {
            Debug.Log("Wave Habis");
            EndStage();

        }
    }
    public void EndStage()
    {
        if (GameManager.Instance.isgameOver)
            return;
        if (currentStageCount  < easyStages.Count)
        {
            // NextStage();
            // Invoke("NextStage", 3f);
            StartCoroutine(StageDone());
        }
        else {
            Debug.Log("Stage Habis");
            Invoke("StageHabis", 3f);
          
        }
     
    }
    public IEnumerator StageDone()
    {
        yield return new WaitForSeconds(3);
        UIManager.Instance.OpenUpgradePanel();
        GameManager.Instance.isInUI = true;
    }
    public void StageHabis()
    {
        GameManager.Instance.GameMenang();
    }
    public void NextStage()
    {
        if (GameManager.Instance.isgameOver)
            return;
        currentStageCount++;
        //cek easy/hard
        if (GameManager.Instance.pathChoosen == path.easy)
        {
            currentStage = easyStages[currentStageCount - 1];
        }
        else if (GameManager.Instance.pathChoosen == path.hard)
        {
            currentStage = hardStages[currentStageCount - 1];
        }
        Debug.Log("Next Stage");
        waveCount = 0;
        SpawnWave();
    }
  
    public void SpawnWave()
    {
        if (GameManager.Instance.isgameOver)
            return;
        isSelesaiSpawn = false;
        currentWave = currentStage.waves[waveCount];
        StartCoroutine(SpawnM());
    }
    public void AddMusuhKeScene(GameObject g)
    {
        musuhInScene.Add(g);
    }
    public void DeleteMusuhDariScene(GameObject g)
    {
        musuhInScene.Remove(g);
        if (GameManager.Instance.isgameOver)
            return;
        CheckMusuhHabis();
    }
    public void CheckMusuhHabis()
    {
        if (isSelesaiSpawn)
        {
            if (musuhInScene.Count < 1)
            {
                NextWave();
            }
        }
    }

    private void Start()
    {
    
        currentStageCount = 1;
        currentStage = easyStages[0];
        currentWave = currentStage.waves[waveCount];
        Invoke("SpawnWave", 3f);
    }
    public IEnumerator SpawnM()
    {

        for (int i = 0; i < currentWave.musuh.Count; i++)
        {
            yield return new WaitForSeconds(currentWave.musuh[i].delay);
            GameObject m = GetMusuh(currentWave.musuh[i].nama);
            if (m != null)
            {
                m.transform.position = new Vector2(posx, currentWave.musuh[i].startingY);
                m.SetActive(true);
                m.GetComponent<Musuh>().Setup();
                AddMusuhKeScene(m);
            }
        }
        //NextWave();
        isSelesaiSpawn = true;
    }
    public GameObject GetMusuh(string nama)
        {
            GameObject g = null;
            if (nama == "Musuh 1")
            {
                g = ObjectPool.Instance.GetMusuh1();
            } else if (nama == "Musuh 2")
            {
                g = ObjectPool.Instance.GetMusuh2();
            }
            else if (nama == "Musuh 3")
            {
                g = ObjectPool.Instance.GetMusuh3();
            }
            else if (nama == "Musuh 4")
            {
                g = ObjectPool.Instance.GetMusuh4();
            }
            else if (nama == "Musuh 5")
            {
                g = ObjectPool.Instance.GetMusuh5();
            }
            else if (nama == "Musuh 6")
            {
                g = ObjectPool.Instance.GetMusuh6();
            }
            else if (nama == "Musuh 7")
            {
                g = ObjectPool.Instance.GetMusuh7();
        }
        else if (nama == "Musuh 8")
        {
            g = ObjectPool.Instance.GetMusuh8();
        }
        return g;
        }


       
     
     
}

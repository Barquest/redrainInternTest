using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [Header("Pool")]
    public List<GameObject> bullet;
    public List<GameObject> Musuh1;
    public List<GameObject> Musuh2;
    public List<GameObject> Musuh3;
    public List<GameObject> Musuh4;
    public List<GameObject> Musuh5;
    public List<GameObject> Musuh6;
    public List<GameObject> Musuh7;
    public List<GameObject> Musuh8;
    public List<GameObject> sp;
    public List<GameObject> bulletImpact;
    public List<GameObject> destroyedParticle;
    public GameObject bulletPoolObject;
    public GameObject spPickupPoolObject;
    public GameObject bulletImpactPoolObject;
    public GameObject destroyedParticlePoolObject;
    [Header("Musuh")]
    public GameObject musuh1PoolObject;
    public GameObject musuh2PoolObject;
    public GameObject musuh3PoolObject;
    public GameObject musuh4PoolObject;
    public GameObject musuh5PoolObject;
    public GameObject musuh6PoolObject;
    public GameObject musuh7PoolObject;
    public GameObject musuh8PoolObject;
    public int amountToPool;
    public int amountToPoolOther;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SetupBullet();
        SetupMusuh1();
        SetupMusuh2();
        SetupMusuh3();
        SetupMusuh4();
        SetupMusuh5();
        SetupMusuh6();
        SetupMusuh7();
        SetupMusuh8();
        SetupSp();
        SetupBulletImpact();
        SetupDestroyedParticle();
    }
    public void SetupMusuh1()
    {
        Musuh1 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(musuh1PoolObject);
            tmp.SetActive(false);
            Musuh1.Add(tmp);
        }
    }
    public void SetupMusuh2()
    {
        Musuh2 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(musuh2PoolObject);
            tmp.SetActive(false);
            Musuh2.Add(tmp);
        }
    }
    public void SetupMusuh3()
    {
        Musuh3 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(musuh3PoolObject);
            tmp.SetActive(false);
            Musuh3.Add(tmp);
        }
    }
    public void SetupMusuh4()
    {
        Musuh4 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(musuh4PoolObject);
            tmp.SetActive(false);
            Musuh4.Add(tmp);
        }
    }
    public void SetupMusuh5()
    {
        Musuh5 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(musuh5PoolObject);
            tmp.SetActive(false);
            Musuh5.Add(tmp);
        }
    }

    public void SetupMusuh6()
    {
        Musuh6 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(musuh6PoolObject);
            tmp.SetActive(false);
            Musuh6.Add(tmp);
        }
    }

    public void SetupMusuh7()
    {
        Musuh7 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(musuh7PoolObject);
            tmp.SetActive(false);
            Musuh7.Add(tmp);
        }
    }
    public void SetupMusuh8()
    {
        Musuh8 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(musuh8PoolObject);
            tmp.SetActive(false);
            Musuh8.Add(tmp);
        }
    }
    public void SetupSp()
    {
        sp = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(spPickupPoolObject);
            tmp.SetActive(false);
            sp.Add(tmp);
        }
    }
    public void SetupBulletImpact()
    {
        bulletImpact = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(bulletImpactPoolObject);
            tmp.SetActive(false);
            bulletImpact.Add(tmp);
        }
    }
    public void SetupDestroyedParticle()
    {
        destroyedParticle = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPoolOther; i++)
        {
            tmp = Instantiate(destroyedParticlePoolObject);
            tmp.SetActive(false);
            destroyedParticle.Add(tmp);
        }
    }
    public GameObject GetSp()
    {
        for (int i = 0; i < sp.Count; i++)
        {
            if (!sp[i].activeInHierarchy)
            {
                return sp[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(spPickupPoolObject);
        sp.Add(tmp);
        return tmp;
    }

    public void SetupBullet()
    {
        bullet = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(bulletPoolObject);
            tmp.SetActive(false);
            bullet.Add(tmp);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < bullet.Count; i++)
        {
            if (!bullet[i].activeInHierarchy)
            {
                return bullet[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(bulletPoolObject);
        bullet.Add(tmp);
        return tmp;
    }
    public GameObject GetMusuh1()
    {
        for (int i = 0; i < Musuh1.Count; i++)
        {
            if (!Musuh1[i].activeInHierarchy)
            {
                return Musuh1[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(musuh1PoolObject);
        Musuh1.Add(tmp);
        return tmp;
    }
    public GameObject GetMusuh2()
    {
        for (int i = 0; i < Musuh2.Count; i++)
        {
            if (!Musuh2[i].activeInHierarchy)
            {
                return Musuh2[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(musuh2PoolObject);
        Musuh2.Add(tmp);
        return tmp;
    }
    public GameObject GetMusuh3()
    {
        for (int i = 0; i < Musuh3.Count; i++)
        {
            if (!Musuh3[i].activeInHierarchy)
            {
                return Musuh3[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(musuh3PoolObject);
        Musuh3.Add(tmp);
        return tmp;
    }
    public GameObject GetMusuh4()
    {
        for (int i = 0; i < Musuh4.Count; i++)
        {
            if (!Musuh4[i].activeInHierarchy)
            {
                return Musuh4[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(musuh4PoolObject);
        Musuh4.Add(tmp);
        return tmp;
    }
    public GameObject GetMusuh5()
    {
        for (int i = 0; i < Musuh5.Count; i++)
        {
            if (!Musuh5[i].activeInHierarchy)
            {
                return Musuh5[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(musuh5PoolObject);
        Musuh5.Add(tmp);
        return tmp;
    }
    public GameObject GetMusuh6()
    {
        for (int i = 0; i < Musuh6.Count; i++)
        {
            if (!Musuh6[i].activeInHierarchy)
            {
                return Musuh6[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(musuh6PoolObject);
        Musuh6.Add(tmp);
        return tmp;
    }
    public GameObject GetMusuh7()
    {
        for (int i = 0; i < Musuh7.Count; i++)
        {
            if (!Musuh7[i].activeInHierarchy)
            {
                return Musuh7[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(musuh7PoolObject);
        Musuh7.Add(tmp);
        return tmp;
    }
    public GameObject GetMusuh8()
    {
        for (int i = 0; i < Musuh8.Count; i++)
        {
            if (!Musuh8[i].activeInHierarchy)
            {
                return Musuh8[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(musuh8PoolObject);
        Musuh8.Add(tmp);
        return tmp;
    }
    public GameObject GetBulletImpact()
    {

        for (int i = 0; i < bulletImpact.Count; i++)
        {
            if (!bulletImpact[i].activeInHierarchy)
            {
                return bulletImpact[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(bulletImpactPoolObject);
        bulletImpact.Add(tmp);
        return tmp;
    }
    public GameObject GetDestroyedParticle()
    {
 
        for (int i = 0; i < destroyedParticle.Count; i++)
        {
            if (!destroyedParticle[i].activeInHierarchy)
            {
                return destroyedParticle[i];
            }
        }
        GameObject tmp;
        tmp = Instantiate(destroyedParticlePoolObject);
        destroyedParticle.Add(tmp);
        return tmp;
    }
}

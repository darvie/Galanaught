using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    [SerializeField] private GameObject pooledBullet;
    [SerializeField] private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;

    private void Awake()
    {
      BulletPool instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        {
            if (bullets.Count > 0)
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].activeInHierarchy)
                    {
                        return bullets[i];
                    }
                    return null;
                }
            }
        }
        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

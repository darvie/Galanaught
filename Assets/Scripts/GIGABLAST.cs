using System.Collections;
using UnityEngine;

public class GIGABLAST : MonoBehaviour
{
        [Header("Bullet Attributes")]
        public GameObject bullet;
        public float bulletLife = 1f;
        public float speed = 1f;

        private GameObject spawnedBullet;

        private void Start()
        {
            StartCoroutine(CountDown());
        }

        IEnumerator CountDown()
        {
            yield return new WaitForSeconds(3);
            Fire();
        }
        private void Fire()
        {
            if (bullet)
            {
                spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                spawnedBullet.GetComponent<BFG>().speed = speed;
                spawnedBullet.GetComponent<BFG>().bulletLife = bulletLife;
                spawnedBullet.transform.rotation = transform.rotation;
            }
        }
    }


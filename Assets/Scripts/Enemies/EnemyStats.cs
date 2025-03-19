using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    [Header("Scripts")]
    public BulletStats bulletStats;

    [Header("Enemy Stats")]
    public float enemyHealth = 100f;   // Initial health of the enemy
    public float enemyDamage = 10f;    // Initial damage of the enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (bulletStats == null)
        {
            bulletStats = FindObjectOfType<BulletStats>(); // Auto-find the script if not assigned
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
    if(!other.gameObject.CompareTag("Bullet"))
        {

        }
        enemyHealth -= bulletDamage;

        if (enemyHealth == 0)
        {

        }
    }


    public void IncreaseStats(float healthIncrease, float damageIncrease)
    {
        enemyHealth += healthIncrease;
        enemyDamage += damageIncrease;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}, Damage = {enemyDamage}");
    }

    public void movement()
    {

    }
}

using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemyHealth = 100f;   // Initial health of the enemy
    public float enemyDamage = 10f;    // Initial damage of the enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
     {
         BulletStats bullet = other.GetComponent<BulletStats>();


         if (bullet != null)
         {
             Debug.Log($"I WAS HIT");
             TakeDamage(bullet.damage);
             Destroy(other.gameObject); // Destroy the bullet after collision
         }
     } 

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log($"I AM HIT");
            TakeDamage(20);
        
    } 

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        Debug.Log($"Enemy hit! Health remaining: {enemyHealth}");

        if (enemyHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy defeated!");
        Destroy(gameObject); // Destroy enemy when health reaches zero
    }



    public void IncreaseStats(float healthIncrease, float damageIncrease)
    {
        enemyHealth += healthIncrease;
        enemyDamage += damageIncrease;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}, Damage = {enemyDamage}");
    }

}

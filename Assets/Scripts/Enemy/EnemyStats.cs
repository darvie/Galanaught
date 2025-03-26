using UnityEngine;
using System.Collections;
using System;
using NUnit.Framework;
using System.Collections.Generic;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemyHealth = 100f;   // Initial health of the enemy
    public float enemyDamage = 10f;    // Initial damage of the enemy

    //LootTable
    [Header("PowerUp")]
    public List<PowerUp> lootTable = new List<PowerUp>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created

<<<<<<< Updated upstream:Assets/Scripts/Enemies/EnemyStats.cs
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
=======
    /*private void OnTriggerEnter(Collider other)
>>>>>>> Stashed changes:Assets/Scripts/Enemy/EnemyStats.cs
     {
         BulletStats bullet = other.GetComponent<BulletStats>();


         if (bullet != null)
         {
             Debug.Log($"I WAS HIT");
             TakeDamage(bullet.damage);
             Destroy(other.gameObject); // Destroy the bullet after collision
         }
     } */

    /*public void OnCollisionEnter(Collision other)
    {
        Debug.Log($"I AM HIT");
            TakeDamage(20);
<<<<<<< Updated upstream:Assets/Scripts/Enemies/EnemyStats.cs
        
    } 
=======

    }*/

    /* void OnTriggerEnter2D(Collider2D other) // Use OnCollisionEnter2D for non-trigger colliders
     {
         Debug.Log("OnTriggerEnter2D detected");
         if (other.CompareTag("Bullet")) // Make sure your bullet has the tag "Bullet"
         {
             TakeDamage();
             TakeDamage(20);
             Destroy(other.gameObject); // Destroy the bullet on impact
         }
     }*/
>>>>>>> Stashed changes:Assets/Scripts/Enemy/EnemyStats.cs

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
                             //Add SFX here when works

        //Spawn Powerup
        foreach (PowerUp powerUp in lootTable)
        {
            if (UnityEngine.Random.Range(0f, 100f) <= powerUp.spawnChance)
            {
                InstantiatePowerUp(powerUp.powerUp);
            }
            break;
        }
    }

    void InstantiatePowerUp(GameObject powerUp)
    {
        if (powerUp)
        {
            GameObject droppedPowerUp = Instantiate(powerUp, transform.position, Quaternion.identity);

        }
        Instantiate(powerUp);
    }

    public void IncreaseStats(float healthIncrease, float damageIncrease)
    {
        enemyHealth += healthIncrease;
        enemyDamage += damageIncrease;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}, Damage = {enemyDamage}");
    }
}

using UnityEngine;
using System.Collections;
using System;
using NUnit.Framework;
using System.Collections.Generic;

public class EnemyStats : MonoBehavior
{
    [Header("Enemy Stats")]
    public float enemyHealth = 100f;   // Initial health of the enemy
 
 //LootTable
    [Header("PowerUp")]
    public List<PowerUp> lootTable = new List<PowerUp>();

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

    public void IncreaseStats(float healthIncrease)
    {
        enemyHealth += healthIncrease;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}");
    }

}

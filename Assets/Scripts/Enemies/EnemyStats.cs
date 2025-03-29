using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemyHealth = 100f;   // Initial health of the enemy
    public float TotalHealth = 0f;


    [Header("Enemy Lifespan")]
    public float LifeSpan = 5f;

    [Header("Sprite Change")]
    public Sprite Death;

    public void Start()
    {
        LifeTime();
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

    public void LifeTime()
    {
        Destroy(gameObject, LifeSpan); // Destroy enemy after certain time in sec
    }
    void Die()
    {
        Debug.Log("Enemy defeated!");
        Destroy(gameObject); // Destroy enemy when health reaches zero
    }



    public void IncreaseStats(float healthIncrease)
    {
        enemyHealth += healthIncrease;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}");
    }

}

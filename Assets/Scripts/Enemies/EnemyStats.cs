using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemyHealth = 100f;   // Initial health of the enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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



    public void IncreaseStats(float healthIncrease)
    {
        enemyHealth += healthIncrease;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}");
    }

}

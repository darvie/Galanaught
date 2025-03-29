using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemyHealth = 100f;   // Initial health of the enemy

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
        KillCounterManager.Instance.IncreaseKillCount();
        Destroy(gameObject); // Destroy enemy when health reaches zero
    }



    public void IncreaseStats(float healthIncrease)
    {
        enemyHealth += healthIncrease;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}");
    }

}

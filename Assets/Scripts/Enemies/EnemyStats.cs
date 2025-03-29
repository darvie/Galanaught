using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemyHealth = 100f;   // Initial health of the enemy

    [Header("Enemy Sprites")]
    public Sprite Dead;

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
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Dead;
        this.gameObject.GetComponent<EnemyStats>().enabled = false;
        Destroy(gameObject, 5f); // Destroy enemy when health reaches zero
    }



    public void IncreaseStats(float healthIncrease)
    {
        enemyHealth += healthIncrease;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}");
    }

}

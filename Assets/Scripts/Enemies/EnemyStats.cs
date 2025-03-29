using UnityEngine;
using System.Collections;
using System;

public class EnemyStats : MonoBehaviour
{

    [Header("Scripts")]
    public GameObject Health;

    [Header("Enemy Stats")]
    public float enemyHealth = 40f;   // Initial health of the enemy
    public float HealthInc = 10f;
    public float DeathAnim = 5f;
    public float KillTime = 50f;

    [Header("Enemy Sprites")]
    public Sprite Dead;

    [Header("Timer Incriments")]
    public float incrementInterval = 10f;  // Time interval to increment stats (1 minute)
    public float Counter;

    public void Start()
    {
        enemyHealth  += Health.GetComponent<HealthTracker>().TotalHP;
        StartCoroutine(AutoKill());
    }

    IEnumerator AutoKill()
    {
        yield return new WaitForSeconds(KillTime);
        Die();
    }

    public void Update()
    {
        Counter += Time.deltaTime;

        if (Counter >= incrementInterval)
        {

            UpdateHealth();
        }
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

        this.gameObject.GetComponent<SpriteRenderer>().sprite = Dead;
        this.gameObject.GetComponent<EnemyStats>().enabled = false;
        Destroy(gameObject, DeathAnim); // Destroy enemy when health reaches zero
    }


    
    public void UpdateHealth()
    {
            enemyHealth += HealthInc;
            Counter = 0;
            Debug.Log($"Enemy stats updated: Health = {enemyHealth}");
        
    }

}

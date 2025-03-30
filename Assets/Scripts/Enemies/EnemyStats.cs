using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{

    [Header("GameObjects")]
    public GameObject Health;
    public GameObject InvulnBuff;
    public GameObject MultiBuff;
    public GameObject GigaBuff;

    [Header("Enemy Stats")]
    public float enemyHealth = 10f;   // Initial health of the enemy
    public float HealthInc = 10f;
    public float DeathAnim = 5f;
    public float KillTime = 50f;
    public float Pspawn;

    [Header("Timer Incriments")]
    public float incrementInterval = 10f;  // Time interval to increment stats (1 minute)
    public float Counter;

    [Header("Death")]
    public GameObject Death;

    [Header("PowerUp Bounds")]
    public int Lower = 1;
    public int Upper = 3;

    public void Start()
    {
        enemyHealth += Health.GetComponent<HealthTracker>().TotalHP;
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
        this.gameObject.GetComponent<EnemyStats>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        Death.SetActive(true);
        Drop();
        Destroy(gameObject, DeathAnim); // Destroy enemy when health reaches zero
        
    }

    private void Drop()
    {
        Pspawn += UnityEngine.Random.Range(1, 9);
        Debug.Log("Number Generated!");

        //Pspawn += 1; Test Value

        if(Pspawn == 1)
        {
            Instantiate(InvulnBuff, transform.position, Quaternion.identity);
        }
        if (Pspawn == 3)
        {
            Instantiate(MultiBuff, transform.position, Quaternion.identity);
        }
        if (Pspawn == 6)
        {
            Instantiate(GigaBuff, transform.position, Quaternion.identity);
        }

    }

    public void UpdateHealth()
    {
        enemyHealth += HealthInc;
        Counter = 0;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}");

    }
}



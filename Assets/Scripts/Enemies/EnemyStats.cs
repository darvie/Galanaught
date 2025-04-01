using UnityEngine;
using System.Collections;
using System;

public class EnemyStats : MonoBehaviour
{

    [Header("Scripts")]
    public GameObject Health;
    public GameObject InvulnBuff;
    public GameObject MultiBuff;
    public GameObject GigaBuff;
    public GameObject HEALING;

    [Header("Enemy Stats")]
    public float enemyHealth = 10f;   // Initial health of the enemy
    public float HealthInc = 10f;
    public float DeathAnim = 5f;
    public float KillTime = 50f;
    public float Pspawn;

    [Header("Timer Increments")]
    public float incrementInterval = 10f;  // Time interval to increment stats (1 minute)
    public float Counter;

    [Header("Death")]
    public GameObject Death;

    [Header("Booleans")]
    public bool Dead;
    public bool chosen = false;

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
        if (!Dead)
        {
            Debug.Log("Enemy defeated!");
            AudioManager.Instance.PlayExplosionSFX();
            Shake.Instance.StartShake();

            this.gameObject.GetComponent<EnemyStats>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Death.SetActive(true);
            Dead = true;
            Drop();
            Destroy(gameObject, DeathAnim); // Destroy enemy when health reaches zero
            KillCounterManager.Instance.IncreaseKillCount();
        }
    }
    private void Drop()
    {
        if (Dead == true)
        {
            if (chosen == false)
            {
                Pspawn += UnityEngine.Random.Range(1, 9);
                chosen = true;
                Debug.Log("Number Generated!");
            }
            

            if (Pspawn == 1 || Pspawn == 4)
            {
                Instantiate(InvulnBuff, transform.position, Quaternion.identity);
                chosen = false;
            }
            else if (Pspawn == 3 || Pspawn == 7)
            {
                Instantiate(MultiBuff, transform.position, Quaternion.identity);
                chosen = false;
            }
            else if (Pspawn == 6)
            {
                Instantiate(GigaBuff, transform.position, Quaternion.identity);
                chosen = false;
            }
            else if (Pspawn == 9 || Pspawn == 2 || Pspawn == 5)
            {
                Instantiate(HEALING, transform.position, Quaternion.identity);
                chosen = false;
            }
        }
    }



    public void UpdateHealth()
    {
        enemyHealth += HealthInc;
        Counter = 0;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}");

    }
}



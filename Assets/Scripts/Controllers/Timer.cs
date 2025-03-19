using UnityEngine;

public class Timer : MonoBehaviour
{
    public EnemyStats enemyStats;

    private float timer = 0f;          // Timer to track time passed
    public float incrementInterval = 60f;  // Time interval to increment stats (1 minute)

    public float HealthInc = 10f;
    public float DamageInc = 2f;

    private void Start()
    {
        if (enemyStats == null)
        {
            enemyStats = FindObjectOfType<EnemyStats>();  // Auto-find the script if not set
        }

        // Start the scaling loop
        InvokeRepeating(nameof(IncrementStats), incrementInterval, incrementInterval);
    }


    // Update is called once per frame
    void Update()
    {
      /*  // Update timer
        timer += Time.deltaTime;

        // Check if one minute has passed
        while (timer >= incrementInterval)
        {
            IncrementStats();
            timer -= incrementInterval;  // Reduce timer by the increment interval for multiple increments
        } */
    } 

    // Method to increment enemy health and damage
    void IncrementStats()
    {
        if (enemyStats != null)
        {
            enemyStats.IncreaseStats(HealthInc, DamageInc);
        }

        // Optional: Print the updated stats to the console
        Debug.Log("Enemy Health: " + enemyStats.enemyHealth);
        Debug.Log("Enemy Damage: " + enemyStats.enemyDamage);
    }
}
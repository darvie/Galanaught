using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Scripts")]
    public EnemyStats enemyStats;


    [Header("Timer Incriments")]
    private float timer = 0f;          // Timer to track time passed
    public float incrementInterval = 60f;  // Time interval to increment stats (1 minute)

    [Header("Enemy Stats")]
    public float HealthInc = 10f;

    [Header("Bullet Damage")]
    public float BDamge = 2f;

    private void Start()
    {
        if (enemyStats == null)
        {
            enemyStats = FindFirstObjectByType<EnemyStats>();  // Auto-find the script if not set
        }

        // Start the scaling loop
        InvokeRepeating(nameof(IncrementStats), timer, incrementInterval);
    }

    // Method to increment enemy health and damage
    void IncrementStats()
    {
        if (enemyStats != null)
        {
            enemyStats.IncreaseStats(HealthInc);
        }

        // Optional: Print the updated stats to the console
        Debug.Log("Enemy Health: " + enemyStats.enemyHealth);
    }
}
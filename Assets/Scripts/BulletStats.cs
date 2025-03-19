using UnityEngine;

public class BulletStats : MonoBehaviour
{
    [Header("Scripts")]
    public EnemyStats EnemyStats;

    [Header("Stats")]
    public float damage = 10f;
    public void IncreaseDamage(float amount)
    {
        damage += amount;
        Debug.Log($"Bullet damage increased: {damage}");
    }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {

        Destroy(gameObject, 5f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Ensure the enemy has the tag "Enemy"
        {
            EnemyStats enemyHealth = other.GetComponent<EnemyStats>();
            if (enemyHealth != null)
            {
                EnemyStats.TakeDamage(damage);
            }

            Destroy(gameObject); // Destroy the bullet after collision
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}

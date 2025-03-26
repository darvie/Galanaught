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
        void Start()
    {

        Destroy(gameObject, 5f);

    }

    /* private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Enemy"))
         {
             EnemyStats enemyHealth = collision.gameObject.GetComponent<EnemyStats>();
             if (enemyHealth != null)
             {
                 enemyHealth.TakeDamage(damage);
             }

             Destroy(gameObject); // Destroy the bullet after impact
         }
     }*/

    public float GetDamage() {
        return damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject); // Destroy bullet on impact
        }
    }
}

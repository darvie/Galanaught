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

    // Update is called once per frame
    void Update()
    {
        
    }
}
